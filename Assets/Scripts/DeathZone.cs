using UnityEngine;
using System.Collections;

public class DeathZone : MonoBehaviour 
{
	private GameController gameController;

	void Awake()
	{
		gameController = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameController> ();
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Player")
		{
			gameController.Die ();
		}
	}

	private void Respawn(float amount)
	{
		// Instantiate blood particle and relocate the player
	}
}
