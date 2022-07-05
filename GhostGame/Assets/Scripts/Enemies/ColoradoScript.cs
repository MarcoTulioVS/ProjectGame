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

	}

	void FixedUpdate(){

		MainController (this.gameObject.name,rb,speed);
		throwPower ();
	}

	//Não necessariamente precisa ser sobrescrito nesse inimigo
	//Trocar para outro se for o caso
	protected override void moveControl(Rigidbody2D rb,float speed){

		float movement = Input.GetAxis ("Horizontal");

		if (movement > 0) {
		
			transform.eulerAngles = new Vector2 (0, 0);

		} else if(movement<0) {
		
			transform.eulerAngles = new Vector2 (0, 180);
		}
			
		rb.velocity = new Vector2(speed * movement,rb.velocity.y);

	}

	void throwPower(){

		if (Input.GetButtonDown ("Fire1") && Time.time > nextFire && isRed) {

			anim.SetBool ("throw", true);
			nextFire = Time.time + fireRate;
			Instantiate (prefabPowerRed, trRefPower.position, Quaternion.identity);
		
		} else if (Input.GetButtonDown ("Fire1") && Time.time > nextFire && !isRed) {

			anim.SetBool ("throw", true);
			nextFire = Time.time + fireRate;
			Instantiate (prefabPowerGreen, trRefPower.position, Quaternion.identity);

		} else {
		
			anim.SetBool ("throw", false);
		}

	}

	void switchPower(){

		if (Input.GetKeyDown(KeyCode.Tab)) {
		
			isRed = !isRed;
		
		}

	}
}
