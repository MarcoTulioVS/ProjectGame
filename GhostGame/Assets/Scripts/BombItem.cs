using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombItem : MonoBehaviour {


	void Start () {
		
	}
	

	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D col){

		if (col.gameObject.tag == "bombItem") {

			Destroy (gameObject);

		}
	}
}
