using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Botolho : MonoBehaviour {


	Animator anim;

	public GameObject endPotal;

	void Start () {
		anim = GetComponent<Animator> ();
	}
	

	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D col){

		if (col.gameObject.tag == "power") {
		
			anim.SetTrigger ("damage");
			endPotal.SetActive (true);
			Destroy (gameObject, 1f);
		
		}
			
	}


}
