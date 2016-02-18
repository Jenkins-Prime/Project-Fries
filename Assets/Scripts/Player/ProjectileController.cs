using UnityEngine;
using System.Collections;

public class ProjectileController : MonoBehaviour {
	Rigidbody2D rb2d;

	public int damage = 1;
	public float projectileSpeed = 10;

	int isRight;
	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();

		if (GameObject.FindGameObjectWithTag ("Player").transform.localScale.x > 0)
			isRight = 1;
		else
			isRight = -1;
		rb2d.velocity = new Vector2 (isRight * projectileSpeed, 0);

	}

	void Update() {	
		transform.RotateAround (transform.position, transform.forward, -isRight*25);
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Enemy") {		
			other.gameObject.GetComponentInParent<EnemyStatus> ().Hit (damage);
		}
		Destroy (gameObject);
	}
}
