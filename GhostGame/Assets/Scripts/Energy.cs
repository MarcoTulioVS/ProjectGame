using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Energy : MonoBehaviour {

	SpriteRenderer sp;
	Collider2D col;


	void Start () {
		col = GetComponent<Collider2D> ();
		sp = GetComponent<SpriteRenderer> ();
	}
	

	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D col){
	
		if (col.gameObject.tag == "Player") {

			StartCoroutine ("DisableAndEnableEnergy");
		
		}
	
	
	}

	IEnumerator DisableAndEnableEnergy(){
			

		sp.enabled = false;
		col.enabled = false;
		yield return new WaitForSeconds (5);
		sp.enabled = true;
		col.enabled = true;

	}
}
