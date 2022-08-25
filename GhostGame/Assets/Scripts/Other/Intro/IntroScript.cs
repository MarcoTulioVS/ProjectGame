using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroScript : MonoBehaviour {

	public List<GameObject> characters;
	public Animator animNomed;
	public AudioSource soundPortal;

	public AudioSource nomedLaugh;

	void Start () {
		StartCoroutine ("IntrorAnimation");
	}
	

	void Update () {
		
	}

	IEnumerator IntrorAnimation(){
	
		for (int i = 1; i < characters.Count - 1; i++) {

			soundPortal.Play ();
			yield return new WaitForSeconds (3.5f);
			characters [i].SetActive (false);
			characters [i + 1].SetActive (true);
			soundPortal.Stop ();

			if (i == 8) {

				nomedLaugh.Play ();
				yield return new WaitForSeconds (3);
				animNomed.SetTrigger ("active");
				yield return new WaitForSeconds (1.16f);
				
			}
		}	
	
	
	}
}
