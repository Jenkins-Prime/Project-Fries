using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {
	public enum MovementType {
		NoMovement,
		LeftRight,
		Hop
	}
	public MovementType movementType;
	float groundCheckDist = 0.1f;
	float wallCheckDist = 0.7f;
	public LayerMask groundLayer;

	public float moveSpeed = 1.0f;
	bool hopped;
	bool isGrounded;
	RaycastHit2D hit;
	Rigidbody2D rb2D;
	EnemyStatus status;

	// Use this for initialization
	void Start () {
		hopped = false;

		rb2D = GetComponent<Rigidbody2D> ();
		status = GetComponent<EnemyStatus> ();
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
			hopped = false;
		} else {
			isGrounded = false;
		}
	}

	void CheckForCollision() {
		//wall check
		hit = Physics2D.Raycast (transform.position, transform.position + transform.right, wallCheckDist, groundLayer);
		if (hit.collider != null) {
			transform.Rotate(0, 180, 0);
		} else {
			//ground check
			//hit = Physics2D.Raycast (checkPos, -transform.up, groundCheckDist, groundLayer);
			if (hit.collider == null) {
				//transform.Rotate(0, 180, 0);
			}
		}
	}

	void Move() {
		switch (movementType) {
			case MovementType.LeftRight:
				rb2D.velocity = new Vector2 (moveSpeed * -transform.right.x, rb2D.velocity.y);
			break;
			case MovementType.Hop:
				if(!hopped) {
					rb2D.velocity = ProjectionVelocity.Calculate(transform.right, 70f);
					hopped = true;					
				}
			break;
		}
	}
}
