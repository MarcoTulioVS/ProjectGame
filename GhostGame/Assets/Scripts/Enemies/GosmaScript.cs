using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GosmaScript : Enemies {

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
		jump (rb, jumpForce);
		GosmaForm ();
		turnVertical ();
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
		
			StartCoroutine ("transitionForm");
			inFormGosma = true;
		} 
			
	}

	void turnVertical(){

		if (colWall) {

			anim.SetInteger ("transition", 4);
		
		}

	}

	IEnumerator transitionForm(){

		anim.SetInteger ("transition",2);
		yield return new WaitForSeconds (0.5f);
		anim.SetInteger ("transition", 3);

	}
}
