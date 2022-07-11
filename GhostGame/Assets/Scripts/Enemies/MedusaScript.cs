using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedusaScript : Enemies {

	Rigidbody2D rb;
	Animator anim;
	public GameObject player;
	public Transform point;
	public float radius;
	public LayerMask layer;
	public GameObject prefabStone;

	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
	}
	

	void Update () {
		getOutBody (player);
	}

	void FixedUpdate(){

		MainController (gameObject.name, rb, anim);
		Petrify ();

	}

	void Petrify(){

		if (Input.GetKeyDown (KeyCode.F)) {
		
			anim.SetInteger ("transition", 2);

			Collider2D col = Physics2D.OverlapCircle (point.position, radius, layer);

			if (col != null) {

				Instantiate (prefabStone, col.transform.position, Quaternion.identity);
				col.gameObject.SetActive (false);

			
			}
		}
	}

	void OnDrawGizmos(){

		Gizmos.DrawWireSphere (point.position, radius);

	}

}
