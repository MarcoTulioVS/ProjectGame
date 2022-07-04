using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPortal : MonoBehaviour {

	private GameObject player;

	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	

	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D col){

		if (col.gameObject.layer == 8) {

			//Quando o portal colidi com algum inimigo, o player(fantasma) sai de dentro do objeto
			//Logo em seguida o objeto é destruido
			Enemies.instance.getOutBodyWhenColliderWithPortal (player);
			Destroy (col.gameObject,0.5f);

			//Verifica se a variavel countEnemies do GameController é igual ao valor da variavel quantMaxEnemies
			//Caso seja vai pra próxima fase
			GameController.instance.GoToNextScene();
		}

	}
}
