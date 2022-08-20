using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour {

	public static SoundController instance;

	public AudioClip[] audios;


	AudioSource a;

	void Awake(){
	
		instance = this;

	}

	void Start () {
		a = GetComponent<AudioSource> ();
	}
	

	void Update () {
		
	}

	public void PlaySound(AudioClip audio){

		a.PlayOneShot (audio);
	
	}
}
