using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerPortal : MonoBehaviour {


	void Start () {
		
	}
	

	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D col){

		if (col.gameObject.tag == "red" || col.gameObject.tag == "red1") {
		
			if (gameObject.name == "powerGreen") {
			
				col.GetComponent<SpriteRenderer> ().color = Color.green;
			
			}
		
		}

		if (col.gameObject.tag == "green" || col.gameObject.tag == "green1") {

			if (gameObject.name == "powerRed") {

				col.GetComponent<SpriteRenderer> ().color = Color.red;

			}

		}



	}
}
