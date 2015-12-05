using UnityEngine;
using System.Collections;

public class ProjectileHit : MonoBehaviour {
	Rigidbody2D rb2d;

	public int damage = 1;

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
	}
	
	void OnCollisionEnter2D(Collision2D other) {
		if (other.collider.tag == "Enemy") {
			other.gameObject.GetComponent<EnemyStatus> ().Hit (damage);
			Destroy(gameObject);
		} else {
			rb2d.velocity = Vector2.zero;
			rb2d.gravityScale = 0f;
			Destroy(gameObject, 0.5f);
		}
	}
}
