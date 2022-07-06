using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shine : MonoBehaviour {

	public GameObject shineObject;
	public static Shine instance;

	void Start(){
		instance = this;

	}

	void Update(){



	}

	public IEnumerable blink(){

		yield return new WaitForSeconds (0.5f);
		this.gameObject.SetActive (false);
	}


}
