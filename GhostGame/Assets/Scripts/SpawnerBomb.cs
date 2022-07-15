using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerBomb : MonoBehaviour {

	public Transform pointSpawnBomb;
	public GameObject prefabBomb;

	GameObject bomb;

	void Start () {
		
	}
	

	void Update () {
		SpawnBomb ();
	}

	void SpawnBomb(){

		if (bomb == null && !Enemies.instance.withBomb) {
			bomb = Instantiate (prefabBomb, pointSpawnBomb.position, Quaternion.identity);
		}

	}
}
