using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubjectController : MonoBehaviour {

	public GameObject moral;
	public GameObject psicologica;
	public GameObject patrimonial;
	public GameObject fisica;
	public GameObject sexual;
	public GameObject conj2;
	public GameObject conj3;
	public GameObject conj4;
	public GameObject conj5;

	public void dialogs(RaycastHit2D hit){
		switch(hit.collider.name){
			case "CasaMoral":
			moral.SetActive(true);
			conj2.SetActive(true);
			Debug.Log(hit.collider.name);
			break;
			case "CasaPsicologica":
			psicologica.SetActive(true);
			conj3.SetActive(true);
			Debug.Log(hit.collider.name);
			break;
			case "CasaPatrimonial":
			patrimonial.SetActive(true);
			conj4.SetActive(true);
			Debug.Log(hit.collider.name);
			break;
			case "CasaFisica":
			fisica.SetActive(true);
			conj5.SetActive(true);
			Debug.Log(hit.collider.name);
			break;
			case "CasaSexual":
			sexual.SetActive(true);
			Debug.Log(hit.collider.name);
			break;
		}
	}
}
