using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatScript : MonoBehaviour {

	Rigidbody2D rb;
	public float speed;


	void Start () {
		rb = GetComponent<Rigidbody2D> ();	
	}
	

	void Update () {
		Move ();
	}

	void Move(){

		rb.velocity = new Vector2 (speed, rb.velocity.y);

	}
}
