using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour {

	Animator anim;
	GameObject[] lista = new GameObject [12];


	void Start () {

		anim = GetComponent<Animator> ();
		lista = GameObject.FindGameObjectsWithTag ("fall");
	}
	

	void Update () {
		
	}
		
	
	void OnCollisionStay2D(Collision2D col){

		if(col.gameObject.tag == "gosma"){

			anim.SetBool ("pressed",true);

			for (int i = 0; i < lista.Length; i++) {

				lista [i].GetComponent<BoxCollider2D> ().enabled = true;

			}

		}

	}

	void OnCollisionExit2D(Collision2D notCol){

		if (notCol.gameObject.tag == "gosma") {

			anim.SetBool ("pressed",false);

			for (int i = 0; i < lista.Length; i++) {

				lista [i].GetComponent<BoxCollider2D> ().enabled = false;

			}
				
		}
	}

}
