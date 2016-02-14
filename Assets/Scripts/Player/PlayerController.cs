using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	Rigidbody2D rb2D;
	Animator anim;

	public float moveSpeed = 1.0f;
	public float jumpHeight = 1.0f;

	bool hasJumped;
	float groundCheck = 0.1f;
	LayerMask groundLayer;

	public bool hasKnockback;

	public bool onLadder;
	public int ladderMode; //0 = not near ladder, 1 = near ladder, 2 = climbing ladder
	public float ladderX;
	public float climbSpeed = 1;

	float gravityValue;
	// Use this for initialization
	void Start () {
		rb2D = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();

		groundLayer = 1 << LayerMask.NameToLayer ("Ground");
		hasKnockback = false;

		onLadder = false;
		ladderMode = 0;

		IsOnGround();
		gravityValue = rb2D.gravityScale;
	}
	
	// Update is called once per frame
	void Update () {
		if (hasKnockback) {
			IsOnGround();
			if(!hasJumped)
				hasKnockback = false;
		} else {
			if(onLadder) {
				float verInput = Input.GetAxisRaw("Vertical");
				if(verInput > 0) {
					rb2D.velocity = new Vector2(rb2D.velocity.x, climbSpeed);
					if(rb2D.gravityScale != 0f)
						rb2D.gravityScale = 0f;
				} else if(verInput < 0) {
					rb2D.velocity = new Vector2(rb2D.velocity.x, -climbSpeed);
					if(rb2D.gravityScale != 0f)
						rb2D.gravityScale = 0f;
				} else {
					rb2D.velocity = new Vector2(rb2D.velocity.x, 0);
				}
			} else {
				if(rb2D.gravityScale == 0) rb2D.gravityScale = gravityValue;
			}

			Move ();
			if (!hasJumped) {
				Jump ();
			} else {
				IsOnGround ();
			}
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

	void IsOnGround() {
		RaycastHit2D hit;
		hit = Physics2D.Raycast (transform.position, -transform.up, groundCheck, groundLayer);
		if (hit.collider != null) {
			hasJumped = false;
			anim.SetBool("isMidair", false);
		}
	}

	void Jump() {
		if (Input.GetButtonDown ("Jump")) {
			rb2D.velocity = new Vector2 (rb2D.velocity.x, jumpHeight);
			hasJumped = true;
			anim.SetBool("isMidair", true);
		}
	}

	public void Knockback(Vector2 knock) {
		hasKnockback = true;
		hasJumped = true; //it isn't  on ground
		rb2D.velocity = new Vector2 (knock.x, knock.y);
	}
}
