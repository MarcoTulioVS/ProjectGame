using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeScript : MonoBehaviour {

	public float speed;
	bool isRight;

	Rigidbody2D rb;

	void Start () {
		
		rb = GetComponent<Rigidbody2D>();
	}
	

	void Update () {
		

	}

	void FixedUpdate(){

		GoAndBack ();
	}

	void GoAndBack(){

		if (isRight) {

			rb.velocity = new Vector2(speed,rb.velocity.y);
		
		} else {

			rb.velocity = new Vector2(-speed,rb.velocity.y);

		}

	}

	void OnTriggerEnter2D(Collider2D col){
	
		if (col.gameObject.tag == "areaSpikeLeft") {
		
			isRight = true;
		
		}

		if (col.gameObject.tag == "areaSpikeRight") {

			isRight = false;

		}

		if (col.gameObject.layer == 8) {

			GameController.instance.DecrementLife ();
		
		}
	
	}

}
