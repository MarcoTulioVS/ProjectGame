using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SalivaScript : Enemies {

	Rigidbody2D rb;
	public GameObject player;
	//public float jumpForce;
	public GameObject prefabBomb;
	public Transform trRefBomb;
	Animator anim;


	void Start () {
		anim = GetComponent<Animator> ();
		rb = GetComponent<Rigidbody2D> ();	
	}
	

	void Update () {
		//getOutBody (player);
		jump (rb, this.jumpForce);
		placeBomb ();
		//showAnimation (anim,"move");
		OnCollisionPortal (gameObject.transform, trRefSecondPortal);
		OnCollisionPortal1 (gameObject.transform, trRefFirstPortal);


	}

	void FixedUpdate(){

		MainController (this.gameObject.name, rb,anim);

	}

	protected override void jump (Rigidbody2D rb, float jumpForce)
	{
		if (Input.GetButtonDown ("Jump") && insideBody) {

			if (!isJumping) {

				rb.AddForce (new Vector2 (0, jumpForce), ForceMode2D.Impulse);
				doubleJump = true;

			} else {

				if (doubleJump) {

					rb.AddForce (new Vector2 (0, jumpForce), ForceMode2D.Impulse);
					doubleJump = false;

				}
			
			}
		}
	}

	void placeBomb(){

		if (Input.GetButtonDown("Fire1") && withBomb && insideBody) {
		
			Instantiate (prefabBomb, trRefBomb.position, Quaternion.identity);
			withBomb = false;
		}

	}
		


}
