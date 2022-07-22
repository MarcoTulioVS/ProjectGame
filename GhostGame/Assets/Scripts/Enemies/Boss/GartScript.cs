using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GartScript : Boss {

	Rigidbody2D rb;
	Animator anim;
	public Transform point;
	public Transform pointBack;
	public float maxVision;
	Vector2 direction;
	SpriteRenderer sp;

	void Start () {

		rb = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		sp = GetComponent<SpriteRenderer> ();

		GetComponent<SpriteRenderer> ().color = Color.green;
		mycolor = sp.color;

		isRight = true;

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
		OnHurt (anim, sp);


	}

	void FixedUpdate(){

		Move (rb, anim,direction);
		OnCollisionWithPlayer (point, pointBack,direction,maxVision,rb,anim);
	}

	void OnDrawGizmos(){
	
		Gizmos.DrawRay (point.position,direction*maxVision);
		Gizmos.DrawRay (pointBack.position, direction*maxVision);
	
	}

	IEnumerator switchColor(){

		while (life > 0) {
			yield return new WaitForSeconds (5);
			sp.color = Color.red;
			yield return new WaitForSeconds (5);
			sp.color = Color.green;
		}
	
	}




}
