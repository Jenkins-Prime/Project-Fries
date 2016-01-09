using UnityEngine;
using System.Collections;

public class EnemyMoveFlyVertical : MonoBehaviour {
	public float flyUpSpeed = 3.0f;
	public float flyDownSpeed = 1.5f;
	public float fallUpCheck = -1.5f;
	public float fallDownCheck = -3.0f;
	public float minDist = 2;
	public float maxDist = 2;
	float startPos;
	bool flyUp;
	Rigidbody2D rb2D;
	
	// Use this for initialization
	void Start () {
		startPos = transform.position.y;
		flyUp = true;
		rb2D = GetComponent<Rigidbody2D> ();
	}
	
	void FixedUpdate () {
		FlyUpDownCheck ();
		Move ();
	}

	void FlyUpDownCheck() {
		if (transform.position.y < startPos - minDist) {
			flyUp = true;
		} else if (transform.position.y > startPos + maxDist) {
			flyUp = false;
		}
	}

	void Move() {
		if (flyUp) {
			FlyUp ();
		} else {
			FlyDown();
		}
	}

	void FlyUp() {
		if (rb2D.velocity.y < fallUpCheck) {
			rb2D.velocity = new Vector2 (rb2D.velocity.x, flyUpSpeed);
		}
	}

	void FlyDown() {
		if (rb2D.velocity.y < fallDownCheck) {
			rb2D.velocity = new Vector2 (rb2D.velocity.x, flyDownSpeed);
		}
	}

	//Visual reference for the min-max Height
	void OnDrawGizmosSelected() {
		if (!Application.isPlaying) {
			startPos = transform.position.y;
		}

		Gizmos.color = Color.red;
		Gizmos.DrawWireCube (new Vector3 (transform.position.x, startPos - (minDist / 2), 1), new Vector3 (0.3f, minDist, 1));
		Gizmos.DrawWireCube (new Vector3 (transform.position.x, startPos + (maxDist / 2), 1), new Vector3 (0.3f, maxDist, 1));
	}
}
