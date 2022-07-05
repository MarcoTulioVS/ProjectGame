using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColoradoScript : Enemies {

	Rigidbody2D rb;
	public float speed;
	public GameObject player;
	public Transform trRefSecondPortal;//ref do portal com tag red1
	public Transform trRefFirstPortal;//ref do portal com tag red

	public GameObject prefabPowerGreen;
	public GameObject prefabPowerRed;

	public Transform trRefPower;
	float fireRate = 0.5f;
	float nextFire;
	Animator anim;

	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
	}
	

	void Update () {

		getOutBody (player);
		OnCollisionPortal (gameObject.transform, trRefSecondPortal);
		OnCollisionPortal1 (gameObject.transform, trRefFirstPortal);

	}

	void FixedUpdate(){

		MainController (this.gameObject.name,rb,speed);
		throwPower ();
	}

	//Não necessariamente precisa ser sobrescrito nesse inimigo
	//Trocar para outro se for o caso
	protected override void moveControl(Rigidbody2D rb,float speed){

		float moveX = Input.GetAxis ("Horizontal");

		if (moveX > 0) {
		
			transform.eulerAngles = new Vector2 (0, 0);

		} else if(moveX<0) {
		
			transform.eulerAngles = new Vector2 (0, 180);
		}

		float moveY = Input.GetAxis ("Vertical");
		Vector3 movement = new Vector3 (moveX, moveY, 0);
		rb.velocity = speed * movement;

	}

	void throwPower(){

		if (Input.GetButtonDown ("Fire1") && Time.time > nextFire) {

			anim.SetBool ("throw", true);
			nextFire = Time.time + fireRate;
			Instantiate (prefabPowerGreen, trRefPower.position, Quaternion.identity);
		
		} else {
		
			anim.SetBool ("throw", false);
		}

	}
}
