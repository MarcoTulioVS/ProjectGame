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

	}



}
