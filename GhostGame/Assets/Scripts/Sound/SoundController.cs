using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour {

	public static SoundController instance;
	public AudioClip sfxPosses;
	public AudioClip sfxFinalPortal;
	public AudioClip sfxStartBossLevel;
	public AudioClip sfxFirstLevel;
	public AudioClip sfxThirdLevel;
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
