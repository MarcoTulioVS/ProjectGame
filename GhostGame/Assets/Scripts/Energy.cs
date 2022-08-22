using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Energy : MonoBehaviour {

	Collider2D c;
	SpriteRenderer sp;

	void Start () {
		c = GetComponent<Collider2D> ();
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
			
		c.enabled = false;
		sp.enabled = false;
		yield return new WaitForSeconds (5);
		c.enabled = true;
		sp.enabled = true;
			
	}
}
