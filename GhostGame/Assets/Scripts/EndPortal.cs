using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPortal : MonoBehaviour {


	void Start () {
		
	}
	

	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D col){

		if (col.gameObject.layer == 8) {
		
			//Verifica se a variavel countEnemies do GameController é igual ao valor da variavel quantMaxEnemies
			//Caso seja vai pra próxima fase
			GameController.instance.GoToNextScene();
		}

	}
}
