using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ButtonManager : MonoBehaviour {

	public void NewGameBtn(string newScene){
		SceneManager.LoadScene(newScene);
	}

	void OnMouseDown () {
   		Debug.Log("Hello");
  	}

   public void CloseGame(){
   		Application.Quit();
   }

   public void CloseDialog(GameObject dialog){
   		dialog.SetActive(false);
   }
}