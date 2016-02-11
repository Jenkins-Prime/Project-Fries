using UnityEngine;
using System.Collections;

public class EnemyStatus : MonoBehaviour {
	GameObject enemy;
	public bool canRespawn;
	Vector3 initPosition;
	Quaternion initRotation;

	public int health = 1;
	int initHealth;
	public bool isDead;
	
	// Use this for initialization
	void Start () {
		enemy = transform.GetChild (0).gameObject;
		initPosition = enemy.transform.position;
		initRotation = enemy.transform.rotation;

		initHealth = health;

		DespawnEnemy ();
		canRespawn = true;
	}
	
	// Update is called once per frame
	void Update () {
		CheckSpawn ();
		//CheckIfDead ();
	}
	
	void SpawnEnemy() {
		//Reset parameters
		enemy.transform.position = initPosition;
		enemy.transform.rotation = initRotation;
		health = initHealth;
		//reset upwards/downwards on flyvertical
		//Spawn
		isDead = false;
		canRespawn = false;
		enemy.SetActive (true);
	}
	
	void DespawnEnemy() {
		enemy.SetActive (false);
		isDead = true;
	}
	
	void CheckIfDead () {
		if (isDead) {
			DespawnEnemy ();
			canRespawn = false;
		}
	}
	
	void CheckSpawn() {
		if (!isDead) { //despawn if camera is 2 times away from enemy
			Vector3 screenPoint = Camera.main.WorldToViewportPoint (transform.position);
			bool onScreen = screenPoint.z > 0 && screenPoint.x > -1 && screenPoint.x < 2 && screenPoint.y > -1 && screenPoint.y < 2;
			if (!onScreen) {
				DespawnEnemy ();
				canRespawn = true;
			}
		} else if (canRespawn) { //spawn if camera is looking at enemy #Change value to 1.5?
			Vector3 screenPoint = Camera.main.WorldToViewportPoint (transform.position);
			bool onScreen = screenPoint.z > 0 && screenPoint.x > 0 && screenPoint.x < 1 && screenPoint.y > 0 && screenPoint.y < 1;
			if (onScreen) {
				SpawnEnemy ();
			}
		} else { //can respawn if it's outside of camera 2x times
			Vector3 screenPoint = Camera.main.WorldToViewportPoint (transform.position);
			bool onScreen = screenPoint.z > 0 && screenPoint.x > -1 && screenPoint.x < 2 && screenPoint.y > -1 && screenPoint.y < 2;
			if (!onScreen) {
				canRespawn = true;
			}
		}
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
