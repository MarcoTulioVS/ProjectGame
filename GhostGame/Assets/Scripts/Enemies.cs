using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour {

	public bool insideBody;
	public static Enemies instance;
	private bool collPortalRed;
	private bool collPortalRed1;
	private bool collPortalGreen;
	private bool collPortalGreen1;
	public float jumpForce;
	public bool isJumping;
	protected bool doubleJump;
	private float movement;
	protected bool activeSpark;
	public bool withBomb;
	public float speed;
	public int life;
	public bool inFormGosma;

	[SerializeField]
	private GameObject shine;

	public bool colWall;

	protected bool isGround; 
	protected bool notColWall;
	public int energyNeeded;

	bool activeDamage;

	public Transform trRefSecondPortal;//ref do portal com tag red1
	public Transform trRefFirstPortal;//ref do portal com tag red

	public Animator colEnemy;
	bool isRight;

	bool stopNormalMove;

	void Awake(){
	
		instance = this;
		activeDamage = true;

	}
	void Start () {
		
	}
	

	void Update () {
		
	}
		



	protected virtual void moveControl(Rigidbody2D rb,Animator anim){

		movement = Input.GetAxis ("Horizontal");

		if (movement > 0) {

			transform.eulerAngles = new Vector2 (0, 0);
		
		} else if (movement < 0) {
		
			transform.eulerAngles = new Vector2 (0, 180);
		
		}

	
		if (movement > 0 && !isJumping) {

			transform.eulerAngles = new Vector2 (0, 0);
			anim.SetInteger ("transition",1);

		} else if (movement < 0 && !isJumping) {

			transform.eulerAngles = new Vector2 (0, 180);
			anim.SetInteger ("transition",1);

		} else if(movement==0 && !isJumping) {
		
			anim.SetInteger ("transition", 0);
		}
			
		rb.velocity = new Vector2 (speed * movement, rb.velocity.y);

	}



	private void MonsterMovement(Rigidbody2D rb,Animator anim){

		if (isRight) {

			rb.velocity = new Vector2 (-speed + 1.5f, rb.velocity.y);
			transform.eulerAngles = new Vector2 (0, 180);
			anim.SetInteger ("transition", 1);

		} else {

			rb.velocity = new Vector2 (speed - 1.5f, rb.velocity.y);
			transform.eulerAngles = new Vector2 (0, 0);
			anim.SetInteger ("transition", 1);
		}
	
	
	
	}



	protected void MainController(string nameObject,Rigidbody2D rb,Animator anim){

		if (Player.instance.activeObject && Player.instance.nameObject == nameObject) {

			rb.constraints = RigidbodyConstraints2D.FreezeRotation;
			stopNormalMove = true;
			moveControl (rb, anim);
			
		} else if(!stopNormalMove) {


			MonsterMovement (rb, anim);
		
		}


	}

	public void getOutBody(GameObject player){

		if((Input.GetKeyDown(KeyCode.Mouse1) || Input.GetKeyDown(KeyCode.JoystickButton2)) && insideBody){
			
			player.SetActive (true);
			Player.instance.activeObject = false;
			insideBody = false;
			lifeBarOnOff ();
			CameraScript.instance.tr = null;
			player.transform.position = PlayerVisible.instance.trObject.position;
			colEnemy.SetInteger ("transition", 0);
			colEnemy.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;

		}
	
	}

	public void getOutBodyWhenColliderWithPortal(GameObject player){

		player.SetActive (true);
		Player.instance.activeObject = false;
		insideBody = false;

	}

	protected virtual void jump(Rigidbody2D rb,float jumpForce){

		if (Input.GetButtonDown("Jump") && !isJumping && insideBody) {
			
			rb.AddForce (new Vector2 (0, jumpForce), ForceMode2D.Impulse);
			SoundController.instance.PlaySound (SoundController.instance.audios [5]);
		
		}
	
	}

	protected virtual void jump(Rigidbody2D rb,float jumpForce,Animator anim){

		if (Input.GetButtonDown("Jump") && !isJumping && insideBody) {

			anim.SetInteger("transition",2);
			rb.AddForce (new Vector2 (0, jumpForce), ForceMode2D.Impulse);
			SoundController.instance.PlaySound (SoundController.instance.audios [5]);
		
		} 
		
	
	}


	protected virtual void OnTriggerEnter2D(Collider2D col){

		if (col.gameObject.tag == "red") {

			collPortalRed= true;
		
		}

		if (col.gameObject.tag == "red1") {
		
			collPortalRed1 = true;
		
		}

		if (col.gameObject.tag == "green") {

			collPortalGreen= true;

		}

		if (col.gameObject.tag == "green1") {

			collPortalGreen1 = true;

		}

		if (col.gameObject.tag == "Player" && GameController.instance.quantEnergy >= Enemies.instance.energyNeeded) {

			StartCoroutine ("blinkShine");

		}
			

		if (col.gameObject.tag == "areaGosma" && gameObject.name=="gosma") {
		
			//teste
			colWall = true;
			notColWall = false;

		}

		if (col.gameObject.tag == "boost") {
		
			if (gameObject.GetComponent<Enemies> ().jumpForce > 0) {

				gameObject.GetComponent<Enemies> ().jumpForce += 10;
				Destroy (col.gameObject);
			}
		
		}

		if (col.gameObject.name == "AreaBombExplosion(Clone)") {
		
			if (insideBody) {

				GameController.instance.DecrementLife (transform);

			}
		
		}

		//Retirar caso nao de certo
		//Verifica se o inimigo colidiu com um checkpoint
		if (col.gameObject.layer == 17) {
		
			GameController.instance.checkPoint = true;
			GameController.instance.trCheckPoint = col.transform;
			StartCoroutine ("MessageCheckpoint");
		}

		if (col.gameObject.tag == "right") {
		
			isRight = true;
		
		}

		if (col.gameObject.tag == "left") {

			isRight = false;

		}

		if (col.gameObject.tag == "bossfight") {

			Camera.main.GetComponent<AudioSource> ().clip = SoundController.instance.audios[13];
			Camera.main.GetComponent<AudioSource> ().Play ();
			col.gameObject.SetActive (false);
			LifeNameBoss.instance.ShowNameAndLife ();
		}
			
	}

	void OnTriggerExit2D(Collider2D notCol){
	
		if (notCol.gameObject.tag == "areaGosma" && gameObject.name=="gosma") {
		
			colWall = false;
			notColWall = true;

		}
	
	}

	protected virtual void OnCollisionEnter2D(Collision2D col){

		if (col.gameObject.layer == 8) {

			if (activeDamage && insideBody) {

				float halfLife = GameController.instance.quantLife / 2;

				if (halfLife < 25 && !GameController.instance.checkPoint) {
				
					GameController.instance.quantLife = 0;
					GameController.instance.GameOver ();

				} else if (halfLife < 25 && GameController.instance.checkPoint) {
					GameController.instance.quantLife = 100;
					GameController.instance.CheckPoint (transform);
				
				}else {
					
					GameController.instance.quantLife -= halfLife;
				}

				activeDamage = false;
			}
			StartCoroutine ("timeInvencible");

		}


		if (col.gameObject.layer == 9) {
		
			isJumping = false;
			isGround = true;
		}

		//Ao colidir com plataformas que caem
		if (col.gameObject.layer == 14) {

			isJumping = false;
		
		}

		if (col.gameObject.tag == "bombItem" && gameObject.name == "saliva") {

			withBomb = true;
			Destroy (col.gameObject);

		}

		if (col.gameObject.tag == "block") {
		
			isJumping = false;
		
		}

	
	}

	protected virtual void OnCollisionExit2D(Collision2D notCol){

		if (notCol.gameObject.layer == 9) {

			isGround = false;
			isJumping = true;
		}
			
	}


	public void OnCollisionPortal(Transform tr,Transform portalRef){
	
		if (collPortalRed) {
			
			GameObject otherPortal = GameObject.FindGameObjectWithTag ("red1");

			if (otherPortal != null) {

				tr.position = portalRef.position;
				collPortalRed = false;
			}
		}

		if (collPortalGreen) {

			GameObject otherPortal = GameObject.FindGameObjectWithTag ("green1");

			if (otherPortal != null) {

				tr.position = portalRef.position;
				collPortalGreen = false;
			}
		}
	
	
	}

	public void OnCollisionPortal1(Transform tr,Transform portalRef){

		if (collPortalRed1) {

			GameObject otherPortal = GameObject.FindGameObjectWithTag ("red");

			if (otherPortal != null) {

				tr.position = portalRef.position;
				collPortalRed1 = false;
			}
		}

		if (collPortalGreen1) {

			GameObject otherPortal = GameObject.FindGameObjectWithTag ("green");

			if (otherPortal != null) {

				tr.position = portalRef.position;
				collPortalGreen1 = false;
			}
		}


	}

	protected void showAnimation(Animator anim,string name){

		if (movement > 0) {
		
			anim.SetBool (name, true);

		} else if (movement < 0) {
		
			anim.SetBool (name, true);
		
		} else {
		
			anim.SetBool (name, false);
		}


	}

	void lifeBarOnOff(){

		//Para a vida
		Color c = GameController.instance.imageLifeBar.color;
		c.a = 0.35f;

		GameController.instance.imageLifeBar.color = c;
		GameController.instance.imageMoldureLifeBar.color = c;

		//Para a energia
		Color c1 = GameController.instance.imageLifeBar.color;
		c1.a = 1;

		GameController.instance.imageBar.color = c1;
		GameController.instance.imageMoldureBar.color = c1;

	}


	IEnumerator blinkShine(){
	
		shine.SetActive (true);
		yield return new WaitForSeconds (0.5f);
		shine.SetActive (false);
	
	}

	IEnumerator timeInvencible(){

		yield return new WaitForSeconds (2);
		activeDamage = true;
	
	}

	public IEnumerator MessageCheckpoint(){

		GameController.instance.msgCheckpoint.enabled = true;
		yield return new WaitForSeconds (3);
		GameController.instance.msgCheckpoint.enabled = false;

	}


}
