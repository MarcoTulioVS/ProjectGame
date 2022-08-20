using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColoradoScript : Enemies {


	Rigidbody2D rb;

	public GameObject player;

	public GameObject prefabPowerGreen;
	public GameObject prefabPowerRed;

	public Transform trRefPower;
	float fireRate = 0.5f;
	float nextFire;


	private Animator anim;

	bool isRed;
	bool isAttacking;


	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
	}
	

	void Update () {

		getOutBody (player);
		OnCollisionPortal (gameObject.transform, trRefSecondPortal);
		OnCollisionPortal1 (gameObject.transform, trRefFirstPortal);
		switchPower ();
		jump (rb, this.jumpForce);


	}

	void FixedUpdate(){

		MainController (this.gameObject.name,rb,anim);
		throwPower ();
	}


	void throwPower(){

		if (Input.GetButtonDown ("Fire1") && Time.time > nextFire && isRed && !isJumping) {

			if (insideBody && Player.instance.activeObject && Player.instance.nameObject == gameObject.name) {
				isAttacking = true;
				anim.SetInteger ("transition", 2);
				nextFire = Time.time + fireRate;
				Instantiate (prefabPowerRed, trRefPower.position, Quaternion.identity);
				SoundController.instance.PlaySound (SoundController.instance.audios [9]);
			}

			StartCoroutine ("AttackFinish");
		
		} else if (Input.GetButtonDown ("Fire1") && Time.time > nextFire && !isRed && !isJumping) {

			if (insideBody && Player.instance.activeObject && Player.instance.nameObject == gameObject.name) {
				isAttacking = true;
				anim.SetInteger ("transition", 2);
				nextFire = Time.time + fireRate;
				Instantiate (prefabPowerGreen, trRefPower.position, Quaternion.identity);
				SoundController.instance.PlaySound (SoundController.instance.audios [9]);
			}
			StartCoroutine ("AttackFinish");

		} 



	}

	void switchPower(){

		if ((Input.GetKeyDown(KeyCode.Tab) || Input.GetKeyDown(KeyCode.JoystickButton5)) && insideBody) {
		
			isRed = !isRed;
		
		}

	}

	protected override void moveControl (Rigidbody2D rb, Animator anim)
	{
		float movement = Input.GetAxis ("Horizontal");

		if (movement > 0) {

			transform.eulerAngles = new Vector2 (0, 0);

		} else if (movement < 0) {

			transform.eulerAngles = new Vector2 (0, 180);

		}


		if (movement > 0 && !isJumping) {

			transform.eulerAngles = new Vector2 (0, 0);
			anim.SetInteger ("transition",1);

		} else if (movement < 0 && !isJumping) {

			transform.eulerAngles = new Vector2 (0, 180);
			anim.SetInteger ("transition",1);

		} else if(movement==0 && !isJumping && !isAttacking) {

			anim.SetInteger ("transition", 0);
		}

		rb.velocity = new Vector2 (speed * movement, rb.velocity.y);
	}

	IEnumerator AttackFinish(){

		yield return new WaitForSeconds (0.33f);
		isAttacking = false;

	}

}
