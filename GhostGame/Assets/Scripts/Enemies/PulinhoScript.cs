using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulinhoScript : Enemies {

	Rigidbody2D rb;
	public float speed;
	public float jumpForce;
	Animator anim;

	void Start () {
		anim = GetComponent<Animator> ();
		rb = GetComponent<Rigidbody2D> ();
	}
	

	void Update () {
		jump (rb, jumpForce, anim);
	}

	void FixedUpdate(){

		MainController (gameObject.name, rb, speed,anim);

	}
}
