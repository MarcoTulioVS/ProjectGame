using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxBlocked : MonoBehaviour {

	public int countActiveButton;

	public static BoxBlocked instance;

	void Awake(){
	
		instance = this;	
	
	}

	void Start () {
		
	}
	

	void Update () {
		Open ();
	}

	void Open(){
	
		if (countActiveButton == 3) {
		
			gameObject.SetActive (false);
		
		}
	
	}
}
