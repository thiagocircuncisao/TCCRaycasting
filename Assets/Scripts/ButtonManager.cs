﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ButtonManager : MonoBehaviour {
	public void ChangeScene(string newScene){
		SceneManager.LoadScene(newScene);
	}

   public void CloseDialog(GameObject dialog){
   		dialog.SetActive(false);
   		Controller2D.inputEnabled = true;
   }

   public void OpenDialog(GameObject dialog){
   		dialog.SetActive(true);
<<<<<<< HEAD
=======
   }

   public void PlaySound(AudioSource audio){
   		audio.Play();
>>>>>>> parent of 04753c3... Fixed bugs and add instructions
   }
}