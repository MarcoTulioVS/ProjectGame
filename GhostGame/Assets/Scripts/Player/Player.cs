using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	Rigidbody2D rb;

	[SerializeField]
	private float speed;
	Vector3 movement;

	void Start () {
		rb = GetComponent<Rigidbody2D> ();	
	}
	

	void Update () {
		
	}

	void FixedUpdate(){

		Move ();

	}

	void Move(){

		float moveX = Input.GetAxis ("Horizontal");
		float moveY = Input.GetAxis ("Vertical");

		movement = new Vector3 (moveX, moveY, 0);

		rb.velocity = movement * speed;

	}
}
