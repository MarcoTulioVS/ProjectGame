using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeNameBoss : MonoBehaviour {

	public List<GameObject> lifes;
	public GameObject nameBoss;

	public static LifeNameBoss instance;

	void Awake(){
	
		instance = this;

	}
	void Start () {
		
	}
	

	void Update () {
		
	}

	public void ShowNameAndLife(){

		for (int i = 0; i < lifes.Count; i++) {
		
			lifes [i].SetActive(true);
		
		}
		nameBoss.SetActive (true);

	}
}
