using UnityEngine;
using System.Collections;

public class PickupLife : MonoBehaviour {
	public int life = 1;
	
	GameController gameController;
	// Use this for initialization
	void Start () {
		gameController = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameController> ();
	}
	
	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Player") {
			gameController.GainLife(life);
			Destroy(gameObject);
		}
	}
}
