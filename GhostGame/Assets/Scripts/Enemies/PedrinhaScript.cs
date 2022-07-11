﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedrinhaScript : Enemies {

	Rigidbody2D rb;
	Animator anim;

	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
	}
	

	void Update () {
		showAnimation (anim, "walk");
	}

	void FixedUpdate(){

		MainController (gameObject.name, rb);

	}


}