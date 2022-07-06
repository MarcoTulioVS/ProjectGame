using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SalivaScript : Enemies {

	Rigidbody2D rb;
	public float speed;
	public GameObject player;
	public float jumpForce;
	public GameObject prefabBomb;
	public Transform trRefBomb;
	public bool withBomb;

	void Start () {
		rb = GetComponent<Rigidbody2D> ();	
	}
	

	void Update () {
		getOutBody (player);
		jump (rb, jumpForce);
		placeBomb ();
	}

	void FixedUpdate(){

		MainController (this.gameObject.name, rb, speed);

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

	void placeBomb(){

		if (Input.GetKeyDown (KeyCode.F) && withBomb) {
		
			Instantiate (prefabBomb, trRefBomb.position, Quaternion.identity);
			withBomb = false;
		}

	}

	protected override void OnTriggerEnter2D (Collider2D col)
	{
		if (col.gameObject.tag == "bombItem") {
		
			withBomb = true;
			Destroy (col.gameObject);
		
		}
	}
}
