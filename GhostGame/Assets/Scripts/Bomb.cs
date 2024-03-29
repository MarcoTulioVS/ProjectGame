﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour {

	public GameObject prefabAreaExplosion;

	void Start () {
		StartCoroutine ("DestroyBomb");
	}
	

	void Update () {
		

	}
		

	IEnumerator DestroyBomb(){

		yield return new WaitForSeconds (2.1f);
		GameObject b = Instantiate (prefabAreaExplosion, transform.position, Quaternion.identity);
		yield return new WaitForSeconds (0.3f);
		SoundController.instance.PlaySound (SoundController.instance.audios [6]);
		Destroy (b);
		yield return new WaitForSeconds (0.2f);
		Destroy (gameObject);


	}

}
