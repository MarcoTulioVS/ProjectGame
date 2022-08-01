using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkullObstacle : MonoBehaviour {

	Rigidbody2D rb;
	public float speed;

	void Start () {
		rb = GetComponent<Rigidbody2D> ();	
	}
	

	void Update () {
		
	}

	void FixedUpdate(){
	
		Move ();
	
	}

	void OnTriggerEnter2D(Collider2D col){
	
		//Ao colidir com parede
		if (col.gameObject.layer == 16) {
		
			speed = -speed;
		
		}

		//Ao colidir com inimigo
		if (col.gameObject.layer == 8) {

			GameController.instance.DecrementLife ();
		
		}
	
	
	}

	void Move(){

		rb.velocity = new Vector2 (speed, rb.velocity.y);

	}


}
