using UnityEngine;
using System.Collections;

public class PowerUp : MonoBehaviour 
{
	public Color[] colour;
	[HideInInspector]
	public bool isPoweredUp;
	private PlayerController playerController;
	private SpriteRenderer playerColour;
	private GameController gameController;

	void Awake()
	{
		playerController = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerController> ();
		playerColour = GameObject.FindGameObjectWithTag ("Player").GetComponent<SpriteRenderer> ();
		gameController = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameController> ();
	}

	void Start () 
	{
		isPoweredUp = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(isPoweredUp)
		{
			playerColour.material.color = colour[Random.Range(0, colour.Length)];

			playerController.jumpHeight = 20.0f;
			playerController.moveSpeed = 10.0f;
			gameController.maxLives = 3;
			gameController.GainHunger(5);
		}
	

	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if(col.gameObject.tag == "Player")
		{
			gameObject.GetComponent<SpriteRenderer>().enabled = false;
			gameObject.GetComponent<BoxCollider2D>().enabled = false;
			isPoweredUp = true;
		}
	}
}
