using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColoradoScript : Enemies {

	Rigidbody2D rb;
	public float speed;
	public GameObject player;
	public Transform trRefSecondPortal;//ref do portal com tag red1
	public Transform trRefFirstPortal;//ref do portal com tag red
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
	}
	

	void Update () {
		getOutBody (player);
		OnCollisionPortal (gameObject.transform, trRefSecondPortal);
		OnCollisionPortal1 (gameObject.transform, trRefFirstPortal);
	}

	void FixedUpdate(){

		MainController (this.gameObject.name,rb,speed);

	}

	//Não necessariamente precisa ser sobrescrito nesse inimigo
	//Trocar para outro se for o caso
	protected override void moveControl(Rigidbody2D rb,float speed){

		float moveX = Input.GetAxis ("Horizontal");
		float moveY = Input.GetAxis ("Vertical");
		Vector3 movement = new Vector3 (moveX, moveY, 0);
		rb.velocity = speed * movement;

	}
}
