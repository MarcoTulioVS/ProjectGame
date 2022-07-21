using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour {

	public float speed;
	public int life;
	public bool isRight;
	public bool activeMove;
	public float stopDistance;


	void Start () {


	}
	

	void Update () {
		
	}

	public void Move(Rigidbody2D rb,Animator anim,Vector2 direction){
	
		if (activeMove) {
			
			if (isRight) {
		
				rb.velocity = new Vector2 (speed, rb.velocity.y);
				anim.SetInteger ("transition", 1);
				transform.eulerAngles = new Vector2 (0, 0);
				direction = Vector2.right;

		
			} else {
		
				rb.velocity = new Vector2 (-speed, rb.velocity.y);
				anim.SetInteger ("transition", 1);
				transform.eulerAngles = new Vector2 (0, 180);
				direction = Vector2.left;
			}
		}
	
	
	}

	public void OnCollisionWithPlayer(Transform point,Transform pointBack,Vector2 direction,float maxVision,Rigidbody2D rb,Animator anim){

		RaycastHit2D hit = Physics2D.Raycast (point.position, direction, maxVision);

		if (hit.collider != null) {
			
			if (hit.transform.CompareTag ("Player")) {

				activeMove = true;

				float distance = Vector2.Distance (transform.position, hit.transform.position);

				if (distance <= stopDistance) {
				
					activeMove = false;
					rb.velocity = Vector2.zero;

					anim.SetInteger ("transition", 2);

				}
			
			}
		
		}

		RaycastHit2D behindHit = Physics2D.Raycast (pointBack.position, -direction, maxVision);

		if (behindHit.collider != null) {
		
			if (behindHit.transform.CompareTag ("Player")) {
			
				isRight = !isRight;
				activeMove = true;
			
			}
		
		}
	}
		
}
