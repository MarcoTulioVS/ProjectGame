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

		MainController (this.gameObject.name,rb);
		throwPower ();
	}


	void throwPower(){

		if (Input.GetButtonDown ("Fire1") && Time.time > nextFire && isRed) {

			if (insideBody && Player.instance.activeObject && Player.instance.nameObject == gameObject.name) {

				anim.SetBool ("throw", true);
				nextFire = Time.time + fireRate;
				Instantiate (prefabPowerRed, trRefPower.position, Quaternion.identity);
			}
		
		} else if (Input.GetButtonDown ("Fire1") && Time.time > nextFire && !isRed) {

			if (insideBody  && Player.instance.activeObject && Player.instance.nameObject == gameObject.name) {
				
				anim.SetBool ("throw", true);
				nextFire = Time.time + fireRate;
				Instantiate (prefabPowerGreen, trRefPower.position, Quaternion.identity);
			}

		} else {
		
			anim.SetBool ("throw", false);
		}

	}

	void switchPower(){

		if ((Input.GetKeyDown(KeyCode.Tab) || Input.GetKeyDown(KeyCode.JoystickButton5)) && insideBody) {
		
			isRed = !isRed;
		
		}

	}


}
