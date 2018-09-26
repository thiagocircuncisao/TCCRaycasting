using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Controller2D))]
public class Player : MonoBehaviour {

	public float jumpHeight = 4;
	public float timeToJumpApex = .4f;
	float accelerationTimeAirBone = .2f;
	float accelerationTimeGrounded = .1f;
	float moveSpeed = 6;
	
	float gravity;
	float jumpVelocity;
	Vector3 velocity;
	float velocityXSmoothing;
	public bool facingRight = true;
	
	public Animator animator;
	private Transform groundCheck;

	Controller2D controller;
	public AudioSource audio;

	void Start () {
		controller = GetComponent<Controller2D> ();
		animator = GetComponent<Animator>();

		gravity = -(2 * jumpHeight) / Mathf.Pow(timeToJumpApex, 2);
		jumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;
	}

	public void OnLanding(){
		animator.SetBool("IsJumping", false);
	}

	private void Flip(){
		facingRight = !facingRight;

		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	void Update(){
		if(controller.collisions.above || controller.collisions.below){
			velocity.y = 0;
			OnLanding();
		}
		
		Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

		if(input.x > 0 && !facingRight){
			Flip();
		}
		
		else if(input.x < 0 && facingRight){
			Flip();
		}

		if(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow) && controller.collisions.below){
			velocity.y = jumpVelocity;
			animator.SetBool("IsJumping", true);
		}
		
		if(controller.collisions.below && (input.x > 0 || input.x < 0) && !audio.isPlaying){
			audio.Play();
		}

		float targetVelocityX = input.x * moveSpeed;
		velocity.x = Mathf.SmoothDamp(velocity.x, targetVelocityX, ref velocityXSmoothing, (controller.collisions.below) ? accelerationTimeGrounded : accelerationTimeAirBone);
		velocity.y += gravity * Time.deltaTime;
		controller.Move(velocity * Time.deltaTime);
		animator.SetFloat("Speed", Mathf.Abs(targetVelocityX));
	}
}
