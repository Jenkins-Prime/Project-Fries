using UnityEngine;
using System.Collections;

public class TopOfLadder : MonoBehaviour 
{
	private EdgeCollider2D top;
	private GameObject player;

	void Awake()
	{
		top = GetComponent<EdgeCollider2D> ();
		player = GameObject.FindGameObjectWithTag("Player");
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Player")
		{

		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		
	}


}
