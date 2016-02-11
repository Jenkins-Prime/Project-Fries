using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public float moveSpeed = 1.0f;
	public float jumpHeight = 1.0f;
	
	bool hasJumped;
	float groundCheck = 0.1f;
	LayerMask groundLayer;

	Rigidbody2D rb2D;
	Animator anim;
	// Use this for initialization
	void Start () {
		groundLayer = 1 << LayerMask.NameToLayer ("Ground");

		rb2D = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();

		IsOnGround();
	}
	
	// Update is called once per frame
	void Update () {
		Move ();

		if (!hasJumped) {
			Jump();
		} else {
			IsOnGround();
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
}
