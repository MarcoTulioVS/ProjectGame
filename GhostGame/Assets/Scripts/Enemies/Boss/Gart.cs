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

	public bool isTired;
	public int life;

	public bool hited;

	public Color mycolor;
	public int countHit;

	public GameObject player;

	float nextHit;
	float hitRate = 2f;

	public bool isDead;



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

		mycolor = sp.color;

	}
		

	void OnMove(){
		
		if (isFront && !isTired) {

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

		HitPlayer ();
		OnMove ();

	}

	void HitPlayer(){

		RaycastHit2D hit = Physics2D.Raycast (point.position, direction, maxVision);

		if (hit.collider != null) {

			if (hit.transform.CompareTag ("colorado")) {

				isFront = true;

				float distance = Vector2.Distance (transform.position, hit.transform.position);

				if (distance <= stopDistance) {

					isFront = false;
					rb.velocity = Vector2.zero;

					anim.SetInteger ("transition", 2);

					if (Time.time>nextHit) {

						GameController.instance.DecrementLife ();
						nextHit = Time.time + hitRate;

					}

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




	void OnCollisionEnter2D(Collision2D col){

		if (col.gameObject.tag == "pedrada") {

			StopCoroutine ("Tired");
			anim.SetBool ("tired", false);
			speed = auxSpeed;

			if (isTired) {

				Die ();
				Destroy (col.gameObject);
				player.SetActive (true);
				isTired = false;

			} 
				
		}

	}


	void OnTriggerEnter2D(Collider2D col){

		if (col.gameObject.tag == "power") {

			if (mycolor == col.gameObject.GetComponent<SpriteRenderer>().color) {

				StartCoroutine ("Tired");
				hited = true;
			}

		}


	}

	void OnTriggerExit2D(Collider2D notCol){

		if (notCol.gameObject.tag == "power") {

			hited = false;

		}


	}


	IEnumerator BlinkHurt(SpriteRenderer sp){

		sp.enabled = false;
		yield return new WaitForSeconds (0.1f);
		sp.enabled = true;

	}

	void Die(){
	
		life--;

		if (life <= 0) {
			isDead = true;
			life = 0;
			anim.SetTrigger ("death");
			Destroy (gameObject,2.5f);
		}
	
	
	}

	IEnumerator Tired(){

		countHit++;

		if (countHit >= 2) {

			isTired = true;
			rb.velocity = Vector2.zero;
			anim.SetBool ("tired", true);
			yield return new WaitForSeconds (15);
			anim.SetBool ("tired", false);
			speed = auxSpeed;

		}
			
	}


		
}


