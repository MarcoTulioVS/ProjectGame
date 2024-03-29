﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsGame : MonoBehaviour {

	public bool insideObject;
	public static ObjectsGame instance;

	void Awake(){

		instance = this;

	}
	void Start () {
		
	}
	

	void Update () {
		
	}

	protected void OnTriggerEnter2D(Collider2D col){

		if (col.gameObject.tag == "bomb") {
			
			Destroy (gameObject,2.6f);
			Destroy (col.gameObject, 2.6f);
		
		}
	}


	protected void MainController(string nameObject,Rigidbody2D rb,float speed){

		if (Player.instance.activeObject && Player.instance.nameObject == nameObject) {

			moveControl (rb,speed);
		}

	}

	protected virtual void moveControl(Rigidbody2D rb,float speed){

		float movement = Input.GetAxis ("Horizontal");
		rb.velocity = new Vector2 (speed * movement, rb.velocity.y);

	}

	public void getOutBody(GameObject player){

		if((Input.GetKeyDown(KeyCode.Mouse1) || Input.GetKeyDown(KeyCode.JoystickButton2)) && insideObject){

			player.SetActive (true);
			Player.instance.activeObject = false;
			insideObject = false;
			player.transform.position = PlayerVisible.instance.trObject.position;
		}

	}
}
