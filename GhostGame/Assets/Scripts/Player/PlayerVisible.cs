using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVisible : MonoBehaviour {

	float posX;
	float posY;
	public Transform trObject;
	// Use this for initialization
	void Start () {
		posX = trObject.transform.position.x;
		posY = trObject.transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnBecameInvisible(){

		RespawnInScenery ();

	}


	void RespawnInScenery(){

		trObject.transform.position = new Vector2 (posX, posY);

	}
}
