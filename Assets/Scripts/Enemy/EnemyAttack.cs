using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour {
	public int health;
	public int attackDamage;
	public float attackRate;

	Transform player;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
