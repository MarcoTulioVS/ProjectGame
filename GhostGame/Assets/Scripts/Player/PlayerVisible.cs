using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVisible : MonoBehaviour {

	float posX;
	float posY;
	public Transform trObject;
	public Transform player;

	void Start () {
		
	}
	

	void Update () {

		posX = trObject.transform.position.x;
		posY = trObject.transform.position.y;

	}



	void OnBecameInvisible(){

		RespawnInScenery ();

	}



	void RespawnInScenery(){
		
		player.transform.position = new Vector2 (posX, posY);

	}
		
}
