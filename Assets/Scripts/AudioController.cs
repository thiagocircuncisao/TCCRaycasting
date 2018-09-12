using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour {
	public AudioSource sound;
	public void PlaySound(AudioClip clip){
		sound.clip = clip;
		sound.Play();
	}
}
