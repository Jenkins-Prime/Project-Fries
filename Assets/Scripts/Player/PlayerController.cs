using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public Rigidbody2D rb2D;
	[HideInInspector]
	public Animator anim;
	
	public float moveSpeed = 1.0f;
	public float jumpHeight = 1.0f;
	public AudioClip jumpSoundEffect;
	public AudioClip climbSoundEffect;
	public AudioClip LandSoundEffect;

	bool canJump;
	float groundCheck = 0.1f;
	LayerMask groundLayer;

	public bool hasKnockback;

	bool onLadder;
	bool onTop;
	public float climbSpeed = 1;

	float gravityValue;
	// Use this for initialization
	void Start () {
		rb2D = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();

		groundLayer = 1 << LayerMask.NameToLayer ("Ground");
		hasKnockback = false;

		onLadder = false;
		onTop = false;

		gravityValue = rb2D.gravityScale;
	}
	
	// Update is called once per frame
	void Update () {
		GroundCheck ();
		Move ();

		if (canJump) {
			Jump();
		}

		if (onLadder) 
		{
			anim.SetBool("isClimbing", true);

			if(Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow))
			{
				anim.SetFloat("climbSpeed", 1.0f);
				AudioManager.instance.PlayDelayAudio(climbSoundEffect);
			}

			ClimbLadder();
		}
		else
		{
			anim.SetBool("isClimbing", false);
		}
	}

	void Move() {
		float input = Input.GetAxisRaw ("Horizontal");
		if(input > 0) {
			if(transform.localScale.x < 0) { //rotate the sprite if is looking left
				transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
			}
			rb2D.velocity = new Vector2 (moveSpeed, rb2D.velocity.y);
			anim.SetBool ("isMoving", true);
		}
		else if (input < 0) {
			if(transform.localScale.x > 0) { //rotate the sprite if is looking right
				transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
			}
			rb2D.velocity = new Vector2 (-moveSpeed, rb2D.velocity.y);
			anim.SetBool("isMoving", true);
		}
		else {
			rb2D.velocity = new Vector2 (0, rb2D.velocity.y);
			anim.SetBool ("isMoving", false);

		}
	}

	void GroundCheck() {
		RaycastHit2D hit;
		hit = Physics2D.Raycast (transform.position, -transform.up, groundCheck, groundLayer);

		//check if is on ground
		if (hit.collider != null) {
			canJump = true;
			anim.SetBool ("isMidair", false);
		} else {
			canJump = false;
		}
	}

	 void Jump() {
		if (Input.GetButtonDown ("Jump")) {
			AudioManager.instance.PlayAudio(jumpSoundEffect);
			rb2D.velocity = new Vector2 (rb2D.velocity.x, jumpHeight);
			canJump = false;
			anim.SetBool("isMidair", true);
		}
	}

	void ClimbLadder() 
	{
		float verInput = Input.GetAxisRaw("Vertical");
		if (verInput != 0) 
		{
			if(rb2D.gravityScale != 0f) 
			{
				rb2D.gravityScale = 0f;
			}

			rb2D.velocity = new Vector2(rb2D.velocity.x, verInput * climbSpeed);
		}

		else if(rb2D.gravityScale == 0f) 
		{   //it is climbing the ladder
			rb2D.velocity = new Vector2(rb2D.velocity.x, 0);
			anim.SetFloat("climbSpeed", 0.0f);

		}
	}

	public void LadderCheck(bool b) 
	{
		if (b) 
		{
			onLadder = true;
		} 
		else 
		{
			onLadder = false;
			rb2D.gravityScale = gravityValue;
		}

	}
	

	public void Knockback(Vector2 knock) {
		hasKnockback = true;
		canJump = false; //it isn't  on ground
		rb2D.velocity = new Vector2 (knock.x, knock.y);
	}
}
