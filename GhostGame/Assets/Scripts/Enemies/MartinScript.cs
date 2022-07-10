using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MartinScript : Enemies {

	Rigidbody2D rb;
	Animator anim;
	public GameObject player;
	public float jumpForce;

	void Start () {
		
		rb = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
	}
	

	void Update () {
		getOutBody (player);
		jump (rb, jumpForce,anim);
	}

	void FixedUpdate(){

		MainController (gameObject.name, rb, anim);

	}
}
