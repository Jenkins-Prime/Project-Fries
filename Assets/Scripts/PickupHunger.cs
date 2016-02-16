using UnityEngine;
using System.Collections;

public class PickupHunger : MonoBehaviour 
{
	GameController gameController;

	void Awake () 
	{
		gameController = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameController> ();
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.tag == "Player")
		{
			gameController.GainHunger(2);
			Destroy(gameObject);
		}
	}
}
