using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MartinScript : Enemies {

	Rigidbody2D rb;
	Animator anim;
	public GameObject player;
	public float jumpForce;

	public Transform pointUp;
	public float radius;
	public LayerMask layer;

	public Transform pointDown;



	void Start () {
		
		rb = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
	}
	

	void Update () {
		getOutBody (player);
		jump (rb, jumpForce,anim);
		hitUpDown ();
	}

	void FixedUpdate(){

		MainController (gameObject.name, rb, anim);

	}

	void hitUpDown(){
	
		Collider2D colUp = Physics2D.OverlapCircle (pointUp.position, radius, layer);
		Collider2D colDown = Physics2D.OverlapCircle (pointDown.position, radius, layer);

		if (colUp != null) {
			
			colUp.gameObject.GetComponent<Rigidbody2D> ().bodyType = RigidbodyType2D.Dynamic;

		
		}

		if (colDown != null) {
			
			colDown.gameObject.GetComponent<Rigidbody2D> ().bodyType = RigidbodyType2D.Dynamic;
		}


	
	}

	void OnDrawGizmos(){

		Gizmos.DrawWireSphere (pointUp.position, radius);
		Gizmos.DrawWireSphere (pointDown.position, radius);
	}


}
