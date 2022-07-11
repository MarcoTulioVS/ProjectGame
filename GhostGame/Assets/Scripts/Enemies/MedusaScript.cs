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
	GameObject stoneInstance;


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

				col.gameObject.SetActive (false);
				stoneInstance = Instantiate (prefabStone, col.transform.position, Quaternion.identity);
				StartCoroutine ("timeDespetrify",col);

	
			}
		}
	}

	void OnDrawGizmos(){

		Gizmos.DrawWireSphere (point.position, radius);

	}


	IEnumerator timeDespetrify(Collider2D c){
	

		yield return new WaitForSeconds (3f);
		stoneInstance.GetComponent<Animator> ().SetTrigger ("breaking");
		yield return new WaitForSeconds (0.7f);
		Destroy (stoneInstance);
		c.gameObject.SetActive (true);
	
	}


}
