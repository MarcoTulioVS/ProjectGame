using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour {

	void Start () {
		

	}
	

	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D col){
	
		if (col.gameObject.layer == 8) {

			GameObject[] lista = new GameObject [13];

			lista = GameObject.FindGameObjectsWithTag ("fall");

			for (int i = 0; i < lista.Length; i++) {
			
				lista [i].GetComponent<BoxCollider2D> ().enabled = true;
			
			}

		}
	
	}


}
