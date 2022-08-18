using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedrinhaScript : Enemies {

	Rigidbody2D rb;
	Animator anim;

	public GameObject player;

	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
	}
	

	void Update () {
		getOutBody (player);
	}

	void FixedUpdate(){

		MainController (gameObject.name, rb,anim);

	}


}
