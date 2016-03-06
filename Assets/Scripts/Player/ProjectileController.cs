using UnityEngine;
using System.Collections;

public class ProjectileController : MonoBehaviour {
	Rigidbody2D rb2d;

	public int damage = 1;
	public float projectileSpeed = 12;
	public float rotationSpeed = 25;
	public Vector2 moveDirection;

	float rotation;

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		rb2d.velocity = moveDirection * projectileSpeed;
		rotation = (moveDirection.x != 0) ? -moveDirection.x * rotationSpeed : -moveDirection.y * rotationSpeed;
	}

	void Update() {	
		transform.RotateAround (transform.position, transform.forward, rotation);
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Enemy") {		
			other.gameObject.GetComponentInParent<EnemyStatus> ().Hit (damage);
		}
		Destroy (gameObject);
	}
}
