using UnityEngine;
using System.Collections;

public class PickupMoney : MonoBehaviour {
	public int money = 1;

	GameController gameController;
	// Use this for initialization
	void Start () {
		gameController = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameController> ();
	}
	
	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Player") {
			gameController.GainMoney(money);
			Destroy(gameObject);
		}
	}
}
