using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour {
	public Text score;
	private int count;

	void Start(){
		count = 5;
		SetScore();
	}

	public void ChangeScene(string newScene){
		SceneManager.LoadScene(newScene);
	}

   	public void CloseDialog(GameObject dialog){
   		dialog.SetActive(false);
   		Controller2D.inputEnabled = true;
   		SetScore();
   	}

   	public void OpenDialog(GameObject dialog){
   		dialog.SetActive(true);
   	}

   	public void PlaySound(AudioSource audio){
   		audio.Play();
   	}

   	private void SetScore(){
	   	if(count >= 0){
			score.text = "Restam" + " " + count + " " + "casas";
			count--;
		}
   }
}