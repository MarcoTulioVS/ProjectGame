using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulinhoScript : Enemies {

	Rigidbody2D rb;
	Animator anim;

	public GameObject player;


	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
	}
	

	void Update () {
		jump (rb, this.jumpForce, anim);
		getOutBody (player);
	}

	void FixedUpdate(){

		MainController (gameObject.name, rb,anim);

	}
		
}
