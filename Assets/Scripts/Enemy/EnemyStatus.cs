using UnityEngine;
using System.Collections;

public class EnemyStatus : MonoBehaviour {
	public int health = 1;
	int initHealth;
	public bool isDead;

	// Use this for initialization
	void Start () {
		initHealth = health;
		isDead = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Hit(int amount) {
		health -= amount;
		//play hit sound
		if (health < 1) { //Die
			isDead = true;
		}
	}

	public void Reset() {
		health = initHealth;
		isDead = false;
	}
}
