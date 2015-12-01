using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	public GameObject enemyPrefab;
	GameObject enemy;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (enemy != null) {
			//despawn if camera is 2 times away from enemy
			Vector3 screenPoint = Camera.main.WorldToViewportPoint(enemy.transform.position);
			bool onScreen = screenPoint.z > 0 && screenPoint.x > -1 && screenPoint.x < 2 && screenPoint.y > -1 && screenPoint.y < 2;
			if (!onScreen)
				DespawnEnemy ();
		} else { //spawn if camera is looking at enemy
			Vector3 screenPoint = Camera.main.WorldToViewportPoint(transform.position);
			bool onScreen = screenPoint.z > 0 && screenPoint.x > 0 && screenPoint.x < 1 && screenPoint.y > 0 && screenPoint.y < 1;
			if (onScreen)
				SpawnEnemy ();
		}
	}

	void SpawnEnemy() {
		enemy = (GameObject)Instantiate (enemyPrefab, transform.position, Quaternion.identity);
		enemy.transform.parent = transform; //add as child on the spawner
	}

	void DespawnEnemy() {
		DestroyObject (enemy);
	}
}
