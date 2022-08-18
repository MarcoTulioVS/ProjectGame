using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogScript : MonoBehaviour {

	Rigidbody2D rb;

	public float speed;
	Animator anim;

	public Transform trPointEnergy;
	public GameObject prefabEnergy;
	GameObject en;
	bool energySpawned;

	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
	}
	

	void Update () {
		
	}

	void FixedUpdate(){

		if (Player.instance.scared && Player.instance.hit.name==gameObject.name) {
			Move ();
		}

	}

	void Move(){
		
		rb.velocity = new Vector2 (speed, rb.velocity.y);
		anim.SetBool ("walking", true);

		if (en == null && !energySpawned) {
		
			en = Instantiate (prefabEnergy, trPointEnergy.position, Quaternion.identity);
			energySpawned = true;
		}

	}

	void OnBecameInvisible(){

		Destroy (gameObject);

	}


}
