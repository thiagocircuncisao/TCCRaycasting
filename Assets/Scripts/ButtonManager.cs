using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ButtonManager : MonoBehaviour {

	private void Update(){
		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		if(Physics.Raycast(ray, out hit, 100.0f)){
			if(hit.transform)
				print("Teste");
		}
	}

	public void NewGameBtn(string newScene){
		SceneManager.LoadScene(newScene);
	}

	void OnMouseDown () {
   		Debug.Log("Hello");
   }
}