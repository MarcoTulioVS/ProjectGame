using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallPlataform : MonoBehaviour {


	bool colUp;
	Rigidbody2D rb;
	public float speed;

	void Start () {
		
		rb = GetComponent<Rigidbody2D> ();
	}
	

	void Update () {
		
	}

	void FixedUpdate(){

		UpDown ();

	}

	void UpDown(){
	
		if (colUp) {
		
			rb.velocity = new Vector2 (rb.velocity.x, -speed);
		
		} else {

			rb.velocity = new Vector2 (rb.velocity.x, speed);
		
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



}
