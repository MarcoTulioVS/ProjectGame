using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerPortal : MonoBehaviour {

	Rigidbody2D rb;
	public float speed;
	Transform trColorado;


	void Start () {

		trColorado = GameObject.FindGameObjectWithTag ("colorado").transform;

		rb = GetComponent<Rigidbody2D> ();

		if (trColorado.eulerAngles.y==0) {
		
			rb.velocity = new Vector2 (speed, rb.velocity.y);
		} else {
			rb.velocity = new Vector2 (-speed, rb.velocity.y);
			
		}

		Destroy (gameObject, 5f);
	}
	

	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D col){

		if (col.gameObject.tag == "red" || col.gameObject.tag == "red1") {
		
			if (gameObject.name == "powerGreen(Clone)") {
			
				col.GetComponent<SpriteRenderer> ().color = Color.green;
			
			}
		
		}

		if (col.gameObject.tag == "green" || col.gameObject.tag == "green1") {

			if (gameObject.name == "powerRed(Clone)") {

				col.GetComponent<SpriteRenderer> ().color = Color.red;

			}

		}
			
	}



}
