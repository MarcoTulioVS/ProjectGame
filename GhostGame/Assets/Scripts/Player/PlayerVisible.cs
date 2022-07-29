using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVisible : MonoBehaviour {

	public float maxX;
	public float minX;


	public Transform trObject;
	public Transform player;

	public static PlayerVisible instance;

	void Awake(){

		instance = this;

	}
	void Start () {

		trObject.transform.position = new Vector3 (trObject.transform.position.x,
			trObject.transform.position.y,0);
	}
	

	void Update () {

		RepositionPlayer ();
	}

	void RepositionPlayer(){
	
		if (player.transform.position.x > maxX || player.transform.position.x<minX) {
		
			player.position = trObject.position;
		
		}
	
	}
		
}
