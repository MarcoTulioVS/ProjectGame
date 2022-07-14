using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformUpDown : MonoBehaviour {


	bool colUp;
	public float speed;

	void Start () {
		
	}
	

	void Update () {
		UpDown ();
	}

	void UpDown(){

		if (colUp) {

			transform.position += Vector3.down * speed * Time.deltaTime; 
		
		} else {
		
			transform.position += Vector3.up * speed * Time.deltaTime; 
		}

	}

	void OnTriggerEnter2D(Collider2D col){

		if (col.gameObject.tag == "colUP") {
		
			colUp = true;
		
		}

		if (col.gameObject.tag == "colDOWN") {

			colUp = false;

		}

	}

	void OnCollisionEnter2D(Collision2D col){

		if (col.gameObject.layer == 8) {

			//Move o player para dentro da plataforma
			//Dessa forma ele não fica quicando
			col.transform.parent = gameObject.transform;

		}


	}

	void OnCollisionExit2D(Collision2D notCol){
	
		if (notCol.gameObject.layer == 8) {

			notCol.transform.parent = null;

		}
	
	}
}
