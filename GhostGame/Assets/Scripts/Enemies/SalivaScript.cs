using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SalivaScript : Enemies {

	Rigidbody2D rb;
	public float speed;
	public GameObject player;
	public float jumpForce;


	void Start () {
		rb = GetComponent<Rigidbody2D> ();	
	}
	

	void Update () {
		getOutBody (player);
		jump (rb, jumpForce);
	}

	void FixedUpdate(){

		MainController (this.gameObject.name, rb, speed);

	}
}
