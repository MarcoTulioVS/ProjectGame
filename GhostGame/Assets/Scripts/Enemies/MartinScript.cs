using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MartinScript : Enemies {

	Rigidbody2D rb;
	Animator anim;
	SpriteRenderer sp;

	public GameObject player;


	public Transform pointUp;
	public float radius;
	public LayerMask layer;

	public Transform pointDown;
	bool changedColor;
	string colorMartin;
	bool turnUptoDown;


	void Start () {

		rb = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		sp = GetComponent<SpriteRenderer> ();

		colorMartin = "w";
	}
	

	void Update () {
		getOutBody (player);
		jump (rb, this.jumpForce,anim);
		HitUpDown ();
		ChangeColor ();
		TurnUpsideDown ();

	}

	void FixedUpdate(){

		MainController (gameObject.name, rb, anim);

	}

	void HitUpDown(){
	
		Collider2D colUp = Physics2D.OverlapCircle (pointUp.position, radius, layer);
		Collider2D colDown = Physics2D.OverlapCircle (pointDown.position, radius, layer);

		if (colUp != null && colorMartin=="w") {
			
			colUp.gameObject.GetComponent<Rigidbody2D> ().bodyType = RigidbodyType2D.Dynamic;
		
		}

		if (colDown != null && colorMartin=="w") {
			
			colDown.gameObject.GetComponent<Rigidbody2D> ().bodyType = RigidbodyType2D.Dynamic;
		}
	
	}

	void ChangeColor(){

		if ((Input.GetKeyDown (KeyCode.Tab) || Input.GetKeyDown(KeyCode.JoystickButton5)) && !changedColor && insideBody) {

			colorMartin = "g";
			sp.color = Color.green;
			changedColor = !changedColor;


		} else if((Input.GetKeyDown (KeyCode.Tab) || Input.GetKeyDown(KeyCode.JoystickButton5)) && changedColor && insideBody)  {

			colorMartin = "w";
			sp.color = Color.white;
			changedColor = !changedColor;

		}

	}

	void TurnUpsideDown(){

		//Sobe
		if (colorMartin == "g" && !turnUptoDown && insideBody) {

			gameObject.GetComponent<Transform> ().eulerAngles = new Vector3 (0, 0, 180);
			gameObject.GetComponent<Rigidbody2D> ().gravityScale = -1;
			turnUptoDown = true;
		
		}

		//Desce
		if (colorMartin == "w" && turnUptoDown && insideBody) {
		
			gameObject.GetComponent<Transform> ().eulerAngles = new Vector3 (0, 0, 0);
			gameObject.GetComponent<Rigidbody2D> ().gravityScale = 1;
			turnUptoDown = false;
		
		}

	}

	void OnDrawGizmos(){

		Gizmos.DrawWireSphere (pointUp.position, radius);
		Gizmos.DrawWireSphere (pointDown.position, radius);

	}

	protected override void moveControl (Rigidbody2D rb, Animator anim)
	{
		//MOVIMENTO FORMA NORMAL
		float movement = Input.GetAxis ("Horizontal");

		if (movement > 0 && colorMartin=="w" && !isJumping) {

			transform.eulerAngles = new Vector3 (0, 0,0);
			anim.SetInteger ("transition",1);

		} else if (movement < 0 && colorMartin=="w" && !isJumping) {

			transform.eulerAngles = new Vector3 (0, 180,0);
			anim.SetInteger ("transition",1);

		} else if(movement==0 && !isJumping && colorMartin=="w") {
			
			anim.SetInteger ("transition", 0);
		}

		//MOVIMENTO FORMA GRAVIDADE INVERTIDA

		if (movement > 0 && colorMartin=="g" && !isJumping) {

			transform.eulerAngles = new Vector3 (0,180,180);
			anim.SetInteger ("transition",1);


		} else if (movement < 0 && colorMartin=="g" && !isJumping) {

			transform.eulerAngles = new Vector3 (0, 0,180);
			anim.SetInteger ("transition",1);

		}else if(movement==0 && !isJumping && colorMartin=="g") {

			anim.SetInteger ("transition", 0);

		}

		rb.velocity = new Vector2 (speed * movement, rb.velocity.y);

	}


}
