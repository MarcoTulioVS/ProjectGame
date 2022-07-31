using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour {

	Animator anim;
	GameObject[] lista = new GameObject [11];
	GameObject[] sprites = new GameObject[15];

	void Start () {

		anim = GetComponent<Animator> ();
		lista = GameObject.FindGameObjectsWithTag ("fall");
		sprites = GameObject.FindGameObjectsWithTag ("fallPlataform");

	}
	

	void Update () {
		
	}
		
	
	void OnCollisionStay2D(Collision2D col){

		if(col.gameObject.tag == "gosma"){

			anim.SetBool ("pressed",true);

			for (int i = 0; i < lista.Length; i++) {

				lista [i].GetComponent<BoxCollider2D> ().enabled = true;

			}

			for (int i = 0; i < sprites.Length; i++) {

				Color c = sprites [0].GetComponent<SpriteRenderer> ().color;
				c.a = 1;
				sprites [i].GetComponent<SpriteRenderer> ().color = c;
			
			}

		}

	}

	void OnCollisionExit2D(Collision2D notCol){

		if (notCol.gameObject.tag == "gosma") {

			anim.SetBool ("pressed",false);

			for (int i = 0; i < lista.Length; i++) {

				lista [i].GetComponent<BoxCollider2D> ().enabled = false;

			}

			for (int i = 0; i < sprites.Length; i++) {

				Color c = sprites [0].GetComponent<SpriteRenderer> ().color;
				c.a = 0.64f;
				sprites [i].GetComponent<SpriteRenderer> ().color = c;

			}
				
		}
	}

}
