using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {
	public enum MovementType {
		NoMovement,
		LeftRight,
		Hop
	}
	public MovementType movementType;

	public float checkDist = 0.1f;
	public LayerMask groundLayer;

	public float moveSpeed = 1.0f;
	bool hopped;
	public float hopDistance = 1.0f;
	public float hopHeight = 1.0f;
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
		CheckForCollision ();
		Move ();
	}

	void CheckForCollision() {
		//check if is on ground
		hit = Physics2D.Raycast (transform.position, -transform.up, checkDist, groundLayer);
		if (hit.collider != null)
			isGrounded = true;
		else
			isGrounded = false;

		if (isGrounded) {
			Vector3 checkPos = transform.position - transform.right/2;
			//check for wall
			hit = Physics2D.Raycast (checkPos, -transform.right, checkDist, groundLayer);
			if (hit.collider != null) {
				transform.Rotate(0, 180, 0);
			} else {
				//check for ground
				hit = Physics2D.Raycast (checkPos, -transform.up, checkDist, groundLayer);
				if (hit.collider == null) {
					transform.Rotate(0, 180, 0);
				}
			}
		}
	}

	void Move() {
		switch (movementType) {
			case MovementType.LeftRight:
				rb2D.velocity = new Vector2 (moveSpeed * -transform.right.x, rb2D.velocity.y);
			break;
			case MovementType.Hop:
				//WIP
				if(!hopped) {
					rb2D.AddForce(new Vector2(hopDistance, hopHeight));
					hopped = true;
				}
			break;
		}
	}
}
