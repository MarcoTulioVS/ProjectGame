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

		if (col.gameObject.tag == "Player") {
		

		
		}

	}
}
