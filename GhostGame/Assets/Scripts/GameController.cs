using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour {

	public static GameController instance;
	public int quantMaxEnemies;
	public int countEnemies;

	void Awake(){

		instance = this;

	}
	void Start () {
		
	}
	

	void Update () {
		
	}

	public void GoToNextScene(){

		countEnemies++;

		if (countEnemies == quantMaxEnemies) {
		
			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
		
		}

	}
}
