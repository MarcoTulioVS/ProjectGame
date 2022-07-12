using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallPlataform : MonoBehaviour {

	public float speed;
	private TargetJoint2D target;
	private BoxCollider2D collisor;

	float posY;

	void Start () {
		target = GetComponent<TargetJoint2D> ();
		collisor = GetComponent<BoxCollider2D> ();
		posY = transform.position.y;
	}
	

	void Update () {
		
	}

	void FixedUpdate(){


	}

	void OnCollisionEnter2D(Collision2D col){

		if (col.gameObject.layer == 8) {


			StartCoroutine ("repositionPlat");

		}

	}

	IEnumerator repositionPlat(){
	
		yield return new WaitForSeconds (2);
		target.enabled = false;
		collisor.enabled = false;
		yield return new WaitForSeconds (1);
		target.enabled = true;
		collisor.enabled = true;
		transform.position = new Vector2 (transform.position.x, posY);
	
	}



}
