using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialButton : MonoBehaviour {

	Animator anim;

	void ShakeOn(){

		anim.SetBool ("shaking",true);
	
	}

	void ShakeOff(){
	
		anim.SetBool ("shaking", false);
	
	}

	void Start(){

		anim = GetComponent<Animator> ();

	}

	void Update(){

		StartCoroutine ("RandomShake");
	}

	IEnumerator RandomShake(){

		yield return new WaitForSeconds (3);
		int val = Random.Range (0, 2);

		if (val == 1) {
			ShakeOn ();
		} else {
		
			ShakeOff ();
		}


	}

}
