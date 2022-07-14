using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public static GameController instance;
	public int quantMaxEnemies;
	public int countEnemies;

	public float quantEnergy;
	public Image imageBar;
	public Image imageMoldureBar;

	public float quantLife;
	public Image imageLifeBar;
	public Image imageMoldureLifeBar;

	void Awake(){

		instance = this;

	}
	void Start () {
		
	}
	

	void Update () {
		imageBar.fillAmount = quantEnergy / 100;
		imageLifeBar.fillAmount = quantLife / 100;
	}

	public void GoToNextScene(){

		countEnemies++;


		if (countEnemies == quantMaxEnemies) {
		
			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
		
		}

	}
}
