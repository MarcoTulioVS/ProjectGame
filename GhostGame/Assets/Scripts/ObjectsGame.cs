using System.Collections;
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

	void OnTriggerEnter2D(Collider2D col){

		if (col.gameObject.tag == "bomb") {
		
			Destroy (gameObject,3.4f);
			Destroy (col.gameObject, 3.4f);
		
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

		if(Input.GetKeyDown(KeyCode.Mouse1) && insideObject){

			player.SetActive (true);
			Player.instance.activeObject = false;
			insideObject = false;

		}

	}
}
