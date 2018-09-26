using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageInGame : MonoBehaviour {
	public Text message;
	private bool messageSend = false;

	void Start(){
		StartCoroutine(ShowInitialMessage());		
	}

	void Update(){
		if(transform.position.x < -1.4 && transform.position.y > 5.4 && messageSend == false)
			StartCoroutine(ShowOpenMessage());
	}

	public IEnumerator ShowInitialMessage(){
		SetMessageHowToMove();
		yield return new WaitForSeconds(1f);
		FadeIn();
		yield return new WaitForSeconds(3f);
		FadeOut();

		SetMessageHowToJump();
		yield return new WaitForSeconds(1f);
		FadeIn();
		yield return new WaitForSeconds(3f);
		FadeOut();
	}

	public IEnumerator ShowOpenMessage(){
		messageSend = true;
		SetMessagHowToOpenDialog();
		FadeIn();
		yield return new WaitForSeconds(3f);
		FadeOut();
	}

	public void SetMessageHowToMove(){
		message.text = "Aperte as setas do teclado para se mover";
	}

	public void SetMessageHowToJump(){
		message.text = "Aperte a seta para cima para pular";
	}

	public void SetMessagHowToOpenDialog(){
		message.text = "Aperte E no local indicado para abrir a janela";
	}

	private void FadeIn(){
		message.color = new Color(message.color.r, message.color.g, message.color.b, 0);
        
	}

	private void FadeOut(){
		message.color = new Color(message.color.r, message.color.g, message.color.b, 1);
        
	}
}