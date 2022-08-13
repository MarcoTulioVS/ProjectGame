using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowTutorialScene : MonoBehaviour {

	void Start () {
		
	}
	

	void Update () {
		StartCoroutine ("DisableArrows");
	}

	IEnumerator DisableArrows(){
	
		if (ObjectsGame.instance.insideObject) {
			yield return new WaitForSeconds (7);
			gameObject.SetActive (false);
		}

	
	}
}
