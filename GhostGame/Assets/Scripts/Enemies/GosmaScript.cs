﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GosmaScript : Enemies {

	Rigidbody2D rb;
	Animator anim;
	public GameObject player;
	public float jumpForce;
	Vector3 move;


	public Transform pointCollider;
	public float radius;
	public LayerMask layerGosma;

	bool form_out;

	void Start () {

		rb = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();

	}
	

	void Update () {
		getOutBody (player);
		jump (rb, jumpForce);
		GosmaForm ();
		turnVertical();

	}

	void FixedUpdate(){

		MainController (gameObject.name, rb, anim);

	}

	protected override void jump (Rigidbody2D rb, float jumpForce)
	{
		if (Input.GetButtonDown ("Jump") && insideBody) {

			if (!isJumping) {

				rb.AddForce (new Vector2 (0, jumpForce), ForceMode2D.Impulse);
				isJumping = true;
				doubleJump = true;

			} else {

				if (doubleJump) {

					rb.AddForce (new Vector2 (0, jumpForce), ForceMode2D.Impulse);
					doubleJump = false;

				}

			}
		}
	}

	void GosmaForm(){

		if (Input.GetKeyDown (KeyCode.F) && !isJumping && insideBody) {

			inFormGosma = !inFormGosma;
			StartCoroutine ("transitionForm");

		} 
			
	}



	void turnVertical(){
	
		Collider2D hit = Physics2D.OverlapCircle (pointCollider.position, radius,layerGosma);

		if (hit != null && inFormGosma) {
			
			anim.SetInteger ("transition", 4);


		} else if(hit==null && notColWall && inFormGosma){

			anim.SetInteger ("transition", 3);
			
		}
	
	}

	void OnDrawGizmos(){

		Gizmos.DrawWireSphere (pointCollider.position, radius);

	}



	IEnumerator transitionForm(){

		if (inFormGosma) {
			anim.SetInteger ("transition", 2);
			yield return new WaitForSeconds (0.5f);
			anim.SetInteger ("transition", 3);
		} else {
			
			anim.SetInteger ("transition", 3);
			yield return new WaitForSeconds (0.4f);
			anim.SetInteger ("transition", 0);
		
		}

	}


	protected override void moveControl (Rigidbody2D rb, Animator anim)
	{
		float moveX = Input.GetAxis ("Horizontal");
		float moveY = Input.GetAxis ("Vertical");

		if (colWall) {
			move = new Vector3 (moveX, moveY, 0);
			rb.velocity = speed * move;
		} else {
		
			rb.velocity = new Vector2 (speed * moveX, rb.velocity.y);
		}


		if (moveX > 0) {

			transform.eulerAngles = new Vector2 (0, 0);

		} else if (moveX < 0) {

			transform.eulerAngles = new Vector2 (0, 180);

		}

		if (moveX > 0 && !isJumping && !inFormGosma) {

			transform.eulerAngles = new Vector2 (0, 0);
			anim.SetInteger ("transition",1);

		} else if (moveX < 0 && !isJumping && !inFormGosma) {

			transform.eulerAngles = new Vector2 (0, 180);
			anim.SetInteger ("transition",1);

		} else if(moveX==0 && !isJumping && !inFormGosma) {

			anim.SetInteger ("transition", 0);
		}

	}
}
