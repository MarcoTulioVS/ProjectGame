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

//	public void MainController(string nameObject,Rigidbody2D rb,float speed){
//
//		if (Player.instance.activeObject && Player.instance.nameObject == nameObject) {
//
//			moveControl (rb,speed);
//		}
//
//	}



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
