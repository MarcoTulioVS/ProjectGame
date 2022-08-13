using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : ObjectsGame {

	float movement;
	public float speed;
	Rigidbody2D rb;
	public GameObject player;

	void Start () {
		rb = GetComponent<Rigidbody2D> ();
	}
	

	void Update () {
		getOutBody (player);
	}

	void FixedUpdate(){

		MainController (gameObject.name, rb, speed);

		if (GameController.instance.GetActualScene () != "opening_1") {
			FreezeBlock ();
		}


	}

	void FreezeBlock(){

		if (Enemies.instance.insideBody) {
		
			rb.constraints = RigidbodyConstraints2D.FreezeAll;

		} else {
		

			rb.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
		
		}

	}




}
