using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour {

	Rigidbody2D rb;

	[SerializeField]
	private float speed;
	Vector3 movement;
	public bool activeObject;
	public string nameObject;

	public static Player instance;

	public GameObject player;

	public Transform pointCollider;
	public float radius;
	public LayerMask animalLayer;

	public Animator anim;
	bool isScaring;
	public bool scared;

	public int energyCollected;

	public Collider2D hit;


	void Awake(){
	
		if (instance == null) {
		
			instance = this;
			DontDestroyOnLoad (this);

		} else if (instance != this) {
		
			Destroy (instance.gameObject);
			instance = this;
			DontDestroyOnLoad (gameObject);
		
		}
	}



	void Start () {
		
		rb = GetComponent<Rigidbody2D> ();

	}
	

	void Update () {


	}

	void FixedUpdate(){

		Move ();
		Scare ();

	}

	void Move(){

		if (Input.touchCount > 0 && !isScaring) {
		
			Touch t = Input.GetTouch (0);

			if (t.phase == TouchPhase.Moved) {

				transform.position += (Vector3)t.deltaPosition / speed;

				if (t.deltaPosition.x> 0) {
					
					anim.SetInteger ("transition", 1);
					player.transform.eulerAngles = new Vector2 (0, 0);

				} else if(t.deltaPosition.x<0) {

					anim.SetInteger ("transition", 1);
					player.transform.eulerAngles = new Vector2 (0, 180);
				}

			}
		}

		if (Input.touchCount == 0 && !isScaring) {
		
			anim.SetInteger ("transition", 0);
		
		}

	}

	void Scare(){
		

		if (Input.GetKeyDown(KeyCode.F)) {

			isScaring = true;
			anim.SetInteger ("transition", 2);
			hit = Physics2D.OverlapCircle (pointCollider.position, radius,animalLayer);

			if (hit != null) {
			
				scared = true;
			
			} else {
			
				scared = false;
			
			}

			StartCoroutine ("resetScare");
		}


	}

	void OnDrawGizmos(){

		Gizmos.DrawWireSphere (pointCollider.position, radius);

	}

	void OnTriggerEnter2D(Collider2D col){

		//Layer 8 = enemies
		//Ao colidir com o inimigo o fantasma o possui
		if (col.gameObject.layer == 8) {

			if (GameController.instance.quantEnergy >= col.gameObject.GetComponent<Enemies>().energyNeeded) {

				activeObject = true;
				nameObject = col.name;
				player.SetActive (false);
				col.gameObject.GetComponent<Enemies>().insideBody=true;
				GameController.instance.quantEnergy -= col.gameObject.GetComponent<Enemies>().energyNeeded;
				CameraScript.instance.tr = col.gameObject.transform;
				SoundController.instance.PlaySound (SoundController.instance.sfxPosses);
				lifeBarOnOff ();
			}


		}

		//Layer 10 = obj(Objects)
		//Ao colidir com algum objeto o fantasma o possui
		if (col.gameObject.layer == 10) {
			
			activeObject = true;
			nameObject = col.name;
			player.SetActive (false);
			col.gameObject.GetComponent<ObjectsGame> ().insideObject = true;
			GameController.instance.rb = col.gameObject.GetComponent<Rigidbody2D> ();
		
		}

		if (col.gameObject.tag == "energy") {
		
			GameController.instance.quantEnergy += energyCollected;
			Destroy (col.gameObject);
		
		}

	}



	IEnumerator resetScare(){
	
		yield return new WaitForSeconds (0.583f);
		isScaring = false;
		scared = false;
	
	}

	void lifeBarOnOff(){

		//Para a vida
		Color c = GameController.instance.imageLifeBar.color;
		c.a = 1;

		GameController.instance.imageLifeBar.color = c;
		GameController.instance.imageMoldureLifeBar.color = c;

		//Para a energia
		Color c1 = GameController.instance.imageLifeBar.color;
		c1.a = 0.35f;

		GameController.instance.imageBar.color = c1;
		GameController.instance.imageMoldureBar.color = c1;

	}

}
