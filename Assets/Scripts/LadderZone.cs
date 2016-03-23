using UnityEngine;
using System.Collections;

public class LadderZone : MonoBehaviour {
	PlayerController playerController;

	// Use this for initialization
	void Awake () 
	{
		playerController = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerController> ();
	}

	void OnTriggerEnter2D(Collider2D other) 
	{
		if (other.tag == "Player")
		{
			playerController.LadderCheck(true);
		}

	}

	void OnTriggerExit2D(Collider2D other) 
	{
		if (other.tag == "Player") 
		{
			playerController.LadderCheck(false);
		}

	}
}
