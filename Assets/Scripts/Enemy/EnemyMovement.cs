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
		if (isGrounded)
			Move ();
		else
			hopped = false;
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
				if(!hopped) {
					rb2D.velocity = CalcAngularVelocity(-transform.right, 70f);
					hopped = true;
				}
			break;
		}
	}

	Vector3 CalcAngularVelocity(Vector3 dir, float angle) {
		dir.y = 0;
		float length = dir.magnitude;
		float a = angle * Mathf.Deg2Rad;  // convert angle to radians
		dir = new Vector3(length, length * Mathf.Tan(a), 0); // set y to the elevation angle
		float vel = Mathf.Sqrt(length * Physics.gravity.magnitude / Mathf.Sin(2 * a)); // calculate the velocity magnitude
		return vel * dir.normalized;
	}
}
