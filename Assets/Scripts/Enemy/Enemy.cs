using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	//TO DO
	/*public enum EnemyType {
		ChickenLeg, KetchupBottle
	}

	public EnemyType enemyType; */

	public GameObject enemyPrefab;
	//add spawn params
	// Use this for initialization
	void Start () {
		Instantiate (enemyPrefab, transform.position, Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
