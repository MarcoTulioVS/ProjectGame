using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AreaBlockOpeningScene : MonoBehaviour {


	void Start () {
		
	}
	

	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D col){
	
		if (col.gameObject.name == "block (8)") {
		
			GameController.instance.GoToNextScene ();
		
		}
	
	
	}
}
