using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gart : MonoBehaviour {

	Rigidbody2D rb;
	public float speed;
	public float maxVision;
	private bool isFront;
	public bool isRight;

	private Vector2 direction;

	public Transform point;
	public Transform behind;

	public float stopDistance;

	Animator anim;

	SpriteRenderer sp;
	float auxSpeed;

	bool isTired;
	public int life;

	public bool hited;

	public Color mycolor;
	int countHit;

	public GameObject player;

	void Start () {
		
		auxSpeed = speed;
		isRight = true;
		rb = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		sp = GetComponent<SpriteRenderer> ();

		GetComponent<SpriteRenderer> ().color = Color.green;

		if (isRight) {

			transform.eulerAngles = new Vector2 (0, 0);
			direction = Vector2.right;


		} else {

			transform.eulerAngles = new Vector2 (0, 180);
			direction = Vector2.left;

		}

		StartCoroutine ("switchColor");
	}


	void Update () {

		DealDamage (anim);

		if (hited) {
			OnHurt (anim, sp,auxSpeed);
		}

		mycolor = sp.color;

		if (isTired) {
			StartCoroutine ("Tired");
		}

	}
		

	void OnMove(){



		if (isFront) {

			anim.SetInteger ("transition", 1);

			if (isRight) {

				transform.eulerAngles = new Vector2 (0, 0);
				direction = Vector2.right;
				rb.velocity = new Vector2 (speed, rb.velocity.y);

			} else {

				transform.eulerAngles = new Vector2 (0, 180);
				direction = Vector2.left;
				rb.velocity = new Vector2 (-speed, rb.velocity.y);

			}

		}

	}

	void FixedUpdate(){

		GetPlayer ();
		OnMove ();

	}

	void GetPlayer(){

		RaycastHit2D hit = Physics2D.Raycast (point.position, direction, maxVision);

		if (hit.collider != null) {

			if (hit.transform.CompareTag ("colorado")) {

				isFront = true;

				float distance = Vector2.Distance (transform.position, hit.transform.position);

				if (distance <= stopDistance) {

					isFront = false;
					rb.velocity = Vector2.zero;

					anim.SetInteger ("transition", 2);

				}

			}

		}

		RaycastHit2D behindHit = Physics2D.Raycast (behind.position, -direction, maxVision);

		if (behindHit.collider != null) {

			if (behindHit.transform.CompareTag ("colorado")) {

				isRight = !isRight;
				isFront = true;

			}

		}

	}

	void OnDrawGizmos(){

		Gizmos.DrawRay (point.position, direction * maxVision);

	}

	void OnDrawGizmosSelected(){


		Gizmos.DrawRay (behind.position, -direction * maxVision);

	}


	IEnumerator switchColor(){

		while (life > 0) {
			yield return new WaitForSeconds (5);
			sp.color = Color.red;
			yield return new WaitForSeconds (5);
			sp.color = Color.green;
		}

	}

	IEnumerator Tired(){

		if (isTired) {

			anim.SetTrigger ("tired");
			speed = 0;
			yield return new WaitForSeconds (15);
			anim.SetInteger ("transition", 1);
			speed = auxSpeed;
			isTired = false;

		} else {

			anim.SetInteger ("transition", 1);
			speed = auxSpeed;

		}

	}



	void OnCollisionEnter2D(Collision2D col){

		if (col.gameObject.tag == "pedrada") {

			hited = true;

			if (isTired) {

				life--;
				isTired = false;
				hited = false;
				Destroy (col.gameObject);
				player.SetActive (true);

			}

		}

	}


	void OnTriggerEnter2D(Collider2D col){

		if (col.gameObject.tag == "power") {

			if (mycolor == col.gameObject.GetComponent<SpriteRenderer>().color) {

				countHit++;
				hited = true;
			}

		}


	}

	void OnTriggerExit2D(Collider2D notCol){

		if (notCol.gameObject.tag == "power") {

			hited = false;

		}


	}



	protected void DealDamage(Animator anim){

		if (countHit >= 2) {

			isTired = true;
			countHit = 0;
		}

	}

	protected void OnHurt(Animator anim,SpriteRenderer sp,float auxSpeed){

		if (hited) {
			anim.SetTrigger ("hurt");
			StartCoroutine ("BlinkHurt", sp);
		} else {

			anim.SetInteger ("transition", 1);
			speed = auxSpeed;

		}

	}



	IEnumerator BlinkHurt(SpriteRenderer sp){

		sp.enabled = false;
		yield return new WaitForSeconds (0.1f);
		sp.enabled = true;

	}
		
}


