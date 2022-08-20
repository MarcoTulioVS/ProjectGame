using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SalivaScript : Enemies {


	Rigidbody2D rb;
	Animator anim;

	public GameObject player;
	public GameObject prefabBomb;
	public Transform trRefBomb;


	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
	}
	

	void Update () {
		getOutBody (player);
		jump (rb, this.jumpForce);
		placeBomb ();
		OnCollisionPortal (gameObject.transform, trRefSecondPortal);
		OnCollisionPortal1 (gameObject.transform, trRefFirstPortal);


	}

	void FixedUpdate(){
		
		MainController (this.gameObject.name, rb,anim);


	}

	protected override void jump (Rigidbody2D rb, float jumpForce)
	{
		if (Input.GetButtonDown("Jump") && insideBody) {

			if (!isJumping) {

				rb.AddForce (new Vector2 (0, jumpForce), ForceMode2D.Impulse);
				doubleJump = true;
				SoundController.instance.PlaySound (SoundController.instance.audios [5]);

			} else {

				if (doubleJump) {

					rb.AddForce (new Vector2 (0, jumpForce), ForceMode2D.Impulse);
					doubleJump = false;
					SoundController.instance.PlaySound (SoundController.instance.audios [5]);
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
