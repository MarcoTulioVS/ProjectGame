using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour {


	void Start () {
		
	}
	

	void Update () {
		DestroyBomb ();
	}





	void DestroyBomb(){

		Destroy (gameObject, 3.4f);

	}
}
