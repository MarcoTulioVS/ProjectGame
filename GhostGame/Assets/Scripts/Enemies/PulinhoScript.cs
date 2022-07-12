using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulinhoScript : Enemies {

	Rigidbody2D rb;
	public float jumpForce;
	Animator anim;
	public GameObject player;

	void Start () {
		anim = GetComponent<Animator> ();
		rb = GetComponent<Rigidbody2D> ();
	}
	

	void Update () {
		jump (rb, jumpForce, anim);
		getOutBody (player);
	}

	void FixedUpdate(){

		MainController (gameObject.name, rb,anim);

	}
		
}
