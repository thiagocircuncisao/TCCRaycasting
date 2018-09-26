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
<<<<<<< HEAD
		
		switch(hit.collider.name){
			case "SwitchMoral":
			moral.SetActive(true);
			conj2.SetActive(true);
			break;
			case "SwitchPsicologica":
			psicologica.SetActive(true);
			conj3.SetActive(true);
			break;
			case "SwitchPatrimonial":
			patrimonial.SetActive(true);
			conj4.SetActive(true);
			break;
			case "SwitchFisica":
			fisica.SetActive(true);
			conj5.SetActive(true);
			break;
			case "SwitchSexual":
			sexual.SetActive(true);
			break;
=======
		if(Input.GetKeyDown(KeyCode.E) && Controller2D.inputEnabled){
			switch(hit.collider.name){
				case "SwitchMoral":
				moral.SetActive(true);
				conj2.SetActive(true);
				Controller2D.inputEnabled = false;
				break;
				case "SwitchPsicologica":
				psicologica.SetActive(true);
				conj3.SetActive(true);
				Controller2D.inputEnabled = false;
				break;
				case "SwitchPatrimonial":
				patrimonial.SetActive(true);
				conj4.SetActive(true);
				Controller2D.inputEnabled = false;
				break;
				case "SwitchFisica":
				fisica.SetActive(true);
				conj5.SetActive(true);
				Controller2D.inputEnabled = false;
				break;
				case "SwitchSexual":
				sexual.SetActive(true);
				Controller2D.inputEnabled = false;
				break;
			}
>>>>>>> parent of 04753c3... Fixed bugs and add instructions
		}
	}
}
