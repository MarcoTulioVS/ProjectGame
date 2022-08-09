using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour {

	public GameObject prefabAreaExplosion;

	void Start () {
		StartCoroutine ("DestroyB");
	}
	

	void Update () {
		

	}
		

	IEnumerator DestroyBomb(){

		yield return new WaitForSeconds (2.3f);
		GameObject b = Instantiate (prefabAreaExplosion, transform.position, Quaternion.identity);
		yield return new WaitForSeconds (0.3f);
		Destroy (gameObject);
		Destroy (b);

	}

}
