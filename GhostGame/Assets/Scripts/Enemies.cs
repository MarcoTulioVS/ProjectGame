using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour {

	public bool insideBody;
	public static Enemies instance;
	bool collPortalRed;
	bool collPortalRed1;
	bool collPortalGreen;
	bool collPortalGreen1;

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

	public void getOutBodyWhenColliderWithPortal(GameObject player){

		player.SetActive (true);
		Player.instance.activeObject = false;
		insideBody = false;

	}



	protected virtual void OnTriggerEnter2D(Collider2D col){

		if (col.gameObject.tag == "red") {

			collPortalRed= true;
		
		}

		if (col.gameObject.tag == "red1") {
		
			collPortalRed1 = true;
		
		}

		if (col.gameObject.tag == "green") {

			collPortalGreen= true;

		}

		if (col.gameObject.tag == "green1") {

			collPortalGreen1 = true;

		}

	}

	public void OnCollisionPortal(Transform tr,Transform portalRef){
	
		if (collPortalRed) {
			
			GameObject otherPortal = GameObject.FindGameObjectWithTag ("red1");

			if (otherPortal != null) {

				tr.position = portalRef.position;
				collPortalRed = false;
			}
		}

		if (collPortalGreen) {

			GameObject otherPortal = GameObject.FindGameObjectWithTag ("green1");

			if (otherPortal != null) {

				tr.position = portalRef.position;
				collPortalGreen = false;
			}
		}
	
	
	}

	public void OnCollisionPortal1(Transform tr,Transform portalRef){

		if (collPortalRed1) {

			GameObject otherPortal = GameObject.FindGameObjectWithTag ("red");

			if (otherPortal != null) {

				tr.position = portalRef.position;
				collPortalRed1 = false;
			}
		}

		if (collPortalGreen1) {

			GameObject otherPortal = GameObject.FindGameObjectWithTag ("green");

			if (otherPortal != null) {

				tr.position = portalRef.position;
				collPortalGreen1 = false;
			}
		}


	}


}
