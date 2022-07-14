using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogScript : MonoBehaviour {

	Rigidbody2D rb;
	public float speed;
	Animator anim;

	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
	}
	

	void Update () {
		
	}

	void FixedUpdate(){

		Move ();

	}

	void Move(){

		rb.velocity = new Vector2 (speed, rb.velocity.y);
		anim.SetBool ("walking", true);

	}


}
