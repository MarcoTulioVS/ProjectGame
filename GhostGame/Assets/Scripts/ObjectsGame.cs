using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsGame : MonoBehaviour {

	public bool insideObject;
	public static ObjectsGame instance;
	GameObject[] blockList;

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

	protected void MoveControl(Rigidbody2D rb,float speed){
	
		if (Input.touchCount > 0) {

			Touch t = Input.GetTouch (0);

			if (t.phase == TouchPhase.Stationary) {

				if (t.position.x >= 400) {
					transform.eulerAngles = new Vector2 (0, 0);
					rb.velocity = new Vector2 (speed, rb.velocity.y);

				} else if (t.position.x <= 80) {
					transform.eulerAngles = new Vector2 (0, 180);
					rb.velocity = new Vector2 (-speed, rb.velocity.y);
				}

			}

			if (t.phase == TouchPhase.Ended) {

				rb.velocity = Vector2.zero;
			}

		}
	
	}

	protected void MainController(string nameObject,Rigidbody2D rb,float speed){

		if (Player.instance.activeObject && Player.instance.nameObject == nameObject) {

			MoveControl (rb,speed);
		}

	}



	public void getOutBody(GameObject player){

		blockList = GameObject.FindGameObjectsWithTag ("block");

		for(int i=0; i <blockList.Length; i++){

			if (blockList[i].GetComponent<ObjectsGame>().insideObject) {

				player.SetActive (true);
				Player.instance.activeObject = false;
				insideObject = false;
				player.transform.position = PlayerVisible.instance.trObject.position;
				blockList = null;
				break;

			}

		}

	}
}
