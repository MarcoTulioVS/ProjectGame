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

	public Transform trPlayer;

	public GameObject panelGameOver;

	public Text textMsg;
	public Text buttonMsg;

	public Image imageEnemy;
	public Text nameEnemyText;
	public Text descriptionEnemy;

	public List<string> listNameEnemies;
	public List<Image> listImagesEnemies;
	public List<string>listDescriptionEnemies;

	int indexNames;
	int maxCountNames;

	int maxCountDescription;
	int minCountDescription;
	int indexDescription;

	void Awake(){

		instance = this;

	}
	void Start () {
		maxCountNames = listNameEnemies.Count;

	}
	

	void Update () {
		imageBar.fillAmount = quantEnergy / 100;
		imageLifeBar.fillAmount = quantLife / 100;

		GetCameraBackToPlayer ();
		SetNameEnemy ();
		SetDescriptionEnemy ();
	}

	public void GoToNextScene(){

		countEnemies++;


		if (countEnemies == quantMaxEnemies) {
			
			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
		
		}

	}

	public void CallScene(int i){

		SceneManager.LoadScene (i);
	}

	void GetCameraBackToPlayer(){
	
		if (CameraScript.instance.tr == null) {
		
			CameraScript.instance.tr = trPlayer;
		
		}
	
	}

	public void DecrementLife(){

		float halfLife = quantLife / 2;

		if (halfLife < 25) {
			
			quantLife = 0;
			GameOver ();
		} else {
				
			quantLife -= halfLife;

		}

	}


	public void GameOver(){

		panelGameOver.SetActive (true);
		textMsg.text = CreateTextTitle ();
		buttonMsg.text = CreateTextButton ();

	}

	public void RestarGame(){

		//Colocar checkPoint caso tenha pegado
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);

	}

	private string CreateTextTitle(){
	
		int number = Random.Range (1, 6);
	
		switch (number) {
	
			case 1:
				return "Acabou pra você meu chapa!!!";
			case 2:
				return "Não deu não!";
			case 3:
				return "Já foi tarde";
			case 4:
				return "Que pena. Ha! Ha!";
			case 5:
				return "Quem sabe da próxima! He He!";
			default:
				return "nada";
		}
	}

	private string CreateTextButton(){

		int number = Random.Range (1, 6);

		switch (number) {

			case 1:
				return "Bora mais uma";
			case 2:
				return "Que não vai dar o que";
			case 3:
				return "E cá vamos nós de novo";
			case 4:
				return "Agora vou jogar sério";
			case 5:
				return "Essa não valeu";
			default:
				return "nada";
		}
	}

	void SetNameEnemy(){

		nameEnemyText.text = listNameEnemies [indexNames]; 
	}


	void SetDescriptionEnemy(){

		switch (nameEnemyText.text) {
			
			case "SALIVA":

				maxCountDescription = 1;
				minCountDescription = 0;
				break;
			case "COLORADO":
				maxCountDescription = 3;
				minCountDescription = 2;
				break;

			default:
				break;

		}

		descriptionEnemy.text = listDescriptionEnemies [indexDescription];


	}

	public void NextName(){
		
		indexNames++;

		if (indexNames > maxCountNames - 1) {
		
			indexNames = maxCountNames - 1;
		
		}

	}

	public void PreviousName(){
		
		indexNames--;

		if (indexNames < 0) {

			indexNames = 0;
		
		}

	}

	public void NextDescription(){

		indexDescription++;

		if (indexDescription > maxCountDescription) {

			indexDescription = maxCountDescription;

		}

	}

	public void PreviousDescription(){

		indexDescription--;

		if (indexDescription < minCountDescription) {

			indexDescription = minCountDescription;

		}

	}


		
}
