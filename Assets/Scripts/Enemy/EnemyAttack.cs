using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour {
	public int attackDamage;
	public float attackRate;

	EnemyStatus status;

	Transform player;
	// Use this for initialization
	void Start () {
		status = GetComponent<EnemyStatus> ();

		player = GameObject.FindGameObjectWithTag ("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Player") {
			//player.knockback();
			//player.GetComponent<Rigidbody2D>().velocity = new Vector2(-1, 10);
		}
	}
}
