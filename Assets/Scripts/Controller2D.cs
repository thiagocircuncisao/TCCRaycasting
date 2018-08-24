﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (BoxCollider2D))]
[RequireComponent(typeof(SubjectController))]
public class Controller2D : MonoBehaviour {
	
	public LayerMask collisionMask;

	const float skinWidth= .015f;
	public int horizontalRaycount = 4;
	public int verticalRaycount = 4;

	float horizontalRayspacing;
	float verticalRayspacing;
	float maxClimbAngle = 80;
	public bool facingRight = true;

	Collider2D collider;
	RaycastOrigins raycastOrigins;
	public CollisionInfo collisions;

	SubjectController sController;

	// Use this for initialization
	void Start () {
		collider = GetComponent<BoxCollider2D> ();
		sController = GetComponent<SubjectController>();
		CalculateRaySpacing();
	}

	private void Flip()
	{
		// Switch the way the player is labelled as facing.
		facingRight = !facingRight;

		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	public void Move(Vector3 velocity, Animator animator){
		UpdateRaycastOrigins();

		collisions.Reset();

		if(velocity.x != 0)
			HorizontalCollisions(ref velocity);
		
		
		if(velocity.y != 0)
			VerticalCollisions(ref velocity);
		
		

		transform.Translate(velocity);

	}

	void VerticalCollisions(ref Vector3 velocity){
		float directionY = Mathf.Sign(velocity.y);
		float rayLength = Mathf.Abs(velocity.y) + skinWidth;

		for(int i = 0; i < verticalRaycount; i++){
			Vector2 rayOrigin = (directionY == -1) ? raycastOrigins.bottomLeft : raycastOrigins.topLeft;
			rayOrigin += Vector2.right * (verticalRayspacing * i + velocity.x);
			RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.up * directionY, rayLength, collisionMask);

			Debug.DrawRay(rayOrigin, Vector2.up * directionY * rayLength, Color.red);
			
			if(hit){
				velocity.y = (hit.distance - skinWidth) * directionY;
				rayLength = hit.distance;

				if(collisions.climbingSlope){

					velocity.x = velocity.y / Mathf.Tan(collisions.slopeAngle * Mathf.Deg2Rad) * Mathf.Sign(velocity.x);
				}

				collisions.below =  directionY == -1;
				collisions.above =  directionY == 1;
			}
		}
	}

	void HorizontalCollisions(ref Vector3 velocity){
		float directionX = Mathf.Sign(velocity.x);
		float rayLength = Mathf.Abs(velocity.x) + skinWidth;

		for(int i = 0; i < horizontalRaycount; i++){
			Vector2 rayOrigin = (directionX == -1) ? raycastOrigins.bottomLeft : raycastOrigins.bottomRight;
			rayOrigin += Vector2.up * (horizontalRayspacing * i);
			RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.right * directionX, rayLength, collisionMask);
			
			Debug.DrawRay(rayOrigin, Vector2.right * directionX * rayLength, Color.red);

			if(hit){

				float slopeAngle = Vector2.Angle(hit.normal, Vector2.up);

				if(i == 0 && slopeAngle<=maxClimbAngle){
					float distanceToSlopeStart = 0;
					if(slopeAngle != collisions.slopeAngleOld){
						distanceToSlopeStart = hit.distance - skinWidth;
						velocity.x -= distanceToSlopeStart * directionX;
					}
					ClimbSlope(ref velocity, slopeAngle);
					velocity.x += distanceToSlopeStart * directionX;
				}

				if(!collisions.climbingSlope || slopeAngle > maxClimbAngle){
					velocity.x = (hit.distance - skinWidth) * directionX;
					rayLength = hit.distance;

					if(collisions.climbingSlope){
						velocity.y = Mathf.Tan(collisions.slopeAngle * Mathf.Deg2Rad) * Mathf.Abs(velocity.x);
					}
				
					collisions.left =  directionX == -1;
					collisions.right =  directionX == 1;
				}

				if(hit.collider != null){
					if(Input.GetKeyDown(KeyCode.E)){
						Debug.Log("Cliquei");
						sController.dialogs(hit);
					}
				}
			}
		}
	}

	void ClimbSlope(ref Vector3 velocity, float slopeAngle){
		float moveDistance = Mathf.Abs(velocity.x);
		float climbVelocityY = Mathf.Sin(slopeAngle * Mathf.Deg2Rad) * moveDistance;
		if(velocity.y <= climbVelocityY){
			velocity.y = climbVelocityY;
			velocity.x = Mathf.Cos(slopeAngle * Mathf.Deg2Rad) * moveDistance * Mathf.Sign(velocity.x);
			collisions.below = true;
			collisions.climbingSlope = true;
			collisions.slopeAngle = slopeAngle;
		}
	}

	void UpdateRaycastOrigins(){
		Bounds bounds = collider.bounds;
		bounds.Expand(skinWidth * -2);

		raycastOrigins.bottomLeft = new Vector2(bounds.min.x, bounds.min.y);
		raycastOrigins.bottomRight = new Vector2(bounds.max.x, bounds.min.y);
		raycastOrigins.topLeft = new Vector2(bounds.min.x, bounds.max.y);
		raycastOrigins.topRight = new Vector2(bounds.max.x, bounds.max.y);
	}

	void CalculateRaySpacing(){
		Bounds bounds = collider.bounds;
		bounds.Expand(skinWidth * -2);

		horizontalRaycount = Mathf.Clamp(horizontalRaycount, 2, int.MaxValue);
		verticalRaycount = Mathf.Clamp(verticalRaycount, 2, int.MaxValue);

		horizontalRayspacing = bounds.size.y / (horizontalRaycount - 1);
		verticalRayspacing	= bounds.size.x / (verticalRaycount - 1);
	}

	struct RaycastOrigins{
		public Vector2 topLeft, topRight;
		public Vector2 bottomLeft, bottomRight;
	}

	public struct CollisionInfo{
		public bool above, below;
		public bool left,right;
		//public LayerMask onGround = ;

		public bool climbingSlope;
		public float slopeAngle, slopeAngleOld;

		public void Reset(){
			above = below = false;
			left = right = false;
			climbingSlope = false;
			slopeAngleOld = slopeAngle;
			slopeAngle = 0;
		}
	}
}
