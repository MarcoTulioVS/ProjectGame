using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour {

	public bool insideBody;
	public static Enemies instance;

	void Awake(){
	
		instance = this;
	}
	void Start () {
		
	}
	

	void Update () {
		
	}
		

	protected virtual void moveControl(Rigidbody2D rb,float speed){

		float movement = Input.GetAxis ("Horizontal");
		rb.velocity = new Vector2 (speed * movement, rb.velocity.y);
	
	}

	protected void MainController(string nameObject,Rigidbody2D rb,float speed){

		if (Player.instance.activeObject && Player.instance.nameObject == nameObject) {

			moveControl (rb,speed);
		}

	}

	public void getOutBody(GameObject player){
	
		if(Input.GetKeyDown(KeyCode.Mouse1) && insideBody){

			player.SetActive (true);
			Player.instance.activeObject = false;
			insideBody = false;

		}
	
	}

}
