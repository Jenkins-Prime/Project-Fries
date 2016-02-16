using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour 
{
	public int attackDamage = 1;
	public float attackRate;
	
	Transform player;
	PlayerController playerController;
	GameController playerHealth;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		playerController = player.GetComponent<PlayerController> ();
		playerHealth = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameController> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Player") {
			if(transform.position.x < player.position.x)
				playerController.Knockback(new Vector2(3f, 6f));
			else
				playerController.Knockback(new Vector2(-3f, 6f));

			//playerHealth.LoseH(attackDamage);
		}
	}
}
