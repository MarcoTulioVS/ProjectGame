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
	bool isAttacking;


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

		if (Input.GetButtonDown("Fire1") && insideBody) {


			anim.SetInteger ("transition", 2);
			StartCoroutine ("timeAttack");

			Collider2D col = Physics2D.OverlapCircle (point.position, radius, layer);

			if (col != null) {

				col.gameObject.SetActive (false);
				stoneInstance = Instantiate (prefabStone, col.transform.position, Quaternion.identity);
				StartCoroutine ("timeDespetrify", col);
	
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

	IEnumerator timeAttack(){

		isAttacking = true;
		yield return new WaitForSeconds (1.8f);
		isAttacking = false;

	}

	protected override void moveControl (Rigidbody2D rb, Animator anim)
	{
		
		float movement = Input.GetAxis ("Horizontal");

		if (movement > 0) {

			transform.eulerAngles = new Vector2 (0, 0);

		} else if (movement < 0) {

			transform.eulerAngles = new Vector2 (0, 180);

		}


		if (movement > 0 && !isJumping && !isAttacking ) {

			transform.eulerAngles = new Vector2 (0, 0);
			anim.SetInteger ("transition",1);

		} else if (movement < 0 && !isJumping && !isAttacking) {

			transform.eulerAngles = new Vector2 (0, 180);
			anim.SetInteger ("transition",1);

		} else if(movement==0 && !isJumping && !isAttacking) {

			anim.SetInteger ("transition", 0);

		}

		rb.velocity = new Vector2 (speed * movement, rb.velocity.y);

	}


}
