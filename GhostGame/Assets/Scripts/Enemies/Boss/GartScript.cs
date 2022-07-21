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

	void Start () {

		rb = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
	
		isRight = true;

		if (isRight) {

			transform.eulerAngles = new Vector2 (0, 0);
			direction = Vector2.right;

		} else {

			transform.eulerAngles = new Vector2 (0, 180);
			direction = Vector2.left;

		}
	}
	

	void Update () {
		

	}

	void FixedUpdate(){

		Move (rb, anim,direction);
		OnCollisionWithPlayer (point, pointBack,direction,maxVision,rb,anim);
	}

	void OnDrawGizmos(){
	
		Gizmos.DrawRay (point.position,direction*maxVision);
		Gizmos.DrawRay (pointBack.position, direction*maxVision);
	
	}


}
