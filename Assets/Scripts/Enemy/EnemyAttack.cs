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
	
}
