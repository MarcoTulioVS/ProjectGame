using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulinhoScript : Enemies {

	Rigidbody2D rb;
	public float speed;

	void Start () {
		rb = GetComponent<Rigidbody2D> ();
	}
	

	void Update () {
		
	}

	void FixedUpdate(){

		MainController (gameObject.name, rb, speed);

	}
}
