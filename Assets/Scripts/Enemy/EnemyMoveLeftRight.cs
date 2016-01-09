using UnityEngine;
using System.Collections;

public class EnemyMoveLeftRight : MonoBehaviour {

	float groundCheckDist = 0.1f;
	float wallCheckDist = 0.8f;
	float voidCheckDist = 2.1f;
	public LayerMask groundLayer;
	
	public float moveSpeed = 1.0f;
	bool isGrounded;
	RaycastHit2D hit;
	Rigidbody2D rb2D;
	
	// Use this for initialization
	void Start () {
		rb2D = GetComponent<Rigidbody2D> ();
	}
	
	void FixedUpdate () {
		CheckIfGrounded ();
		if (isGrounded) {
			CheckForCollision ();
			Move ();
		}
	}
	
	void CheckIfGrounded() {
		hit = Physics2D.Raycast (transform.position, -transform.up, groundCheckDist, groundLayer);
		if (hit.collider != null) {
			isGrounded = true;
		} else {
			isGrounded = false;
		}
	}
	
	void CheckForCollision() {
		//wall check
		hit = Physics2D.Raycast (transform.position, transform.position - transform.right, wallCheckDist, groundLayer);
		if (hit.collider != null) {		
			transform.Rotate(0, 180, 0);
		} else {
			//ground check
			hit = Physics2D.Raycast (transform.position - transform.right, -transform.up, voidCheckDist, groundLayer);
			if (hit.collider == null) {
				transform.Rotate(0, 180, 0);
			}
		}
	}
	
	void Move() {
		rb2D.velocity = new Vector2 (moveSpeed * -transform.right.x, rb2D.velocity.y);
	}
}
