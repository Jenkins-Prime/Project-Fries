using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	public GameObject enemyPrefab;
	GameObject enemy;
	EnemyStatus enemyStatus;
	bool canRespawn;

	// Use this for initialization
	void Start () {
		enemyStatus = null;
		canRespawn = true;
	}

	// Update is called once per frame
	void Update () {
		CheckIfDead ();
		CheckSpawn ();
	}

	void SpawnEnemy() {
		enemy = (GameObject)Instantiate (enemyPrefab, transform.position, Quaternion.identity);
		enemy.transform.parent = transform; //add as child on the spawner
		enemyStatus = enemy.GetComponent<EnemyStatus> ();
	}

	void DespawnEnemy() {
		enemyStatus = null;
		DestroyObject (enemy);
	}

	void CheckIfDead () {
		if (enemyStatus != null && enemyStatus.isDead) {
			DespawnEnemy ();
			canRespawn = false;
		}
	}

	void CheckSpawn() {
		if (enemy != null || !canRespawn) {
			//despawn if camera is 2 times away from enemy that exists OR isKilled
			Vector3 screenPoint = Camera.main.WorldToViewportPoint (transform.position);
			bool onScreen = screenPoint.z > 0 && screenPoint.x > -1 && screenPoint.x < 2 && screenPoint.y > -1 && screenPoint.y < 2;
			if (!onScreen) {
				DespawnEnemy ();
				canRespawn = true;
			}
		} else { //spawn if camera is looking at enemy
			Vector3 screenPoint = Camera.main.WorldToViewportPoint (transform.position);
			bool onScreen = screenPoint.z > 0 && screenPoint.x > 0 && screenPoint.x < 1 && screenPoint.y > 0 && screenPoint.y < 1;
			if (onScreen)
				SpawnEnemy ();
		}
	}
}
