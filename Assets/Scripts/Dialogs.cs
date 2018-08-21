using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogs : MonoBehaviour {

	public GameObject moral;
	public GameObject psicologica;
	public GameObject patrimonial;
	public GameObject fisica;
	public GameObject sexual;
	
	public void InitializeGameObjects(){
		moral = GameObject.FindWithTag("Moral");
		psicologica = GameObject.FindWithTag("Psicologica");
		patrimonial = GameObject.FindWithTag("Patrimonial");
		fisica = GameObject.FindWithTag("Fisica");
		sexual = GameObject.FindWithTag("Sexual");
	}
}
