using UnityEngine;
using System.Collections;

public class TopOfLadder : MonoBehaviour 
{
	private BoxCollider2D top;
	private float gravity;
	private GameObject player;
	private PlayerController playerController;
	private Animator anim;
	private bool canClimbingDown;

	void Awake()
	{
		top = GetComponent<BoxCollider2D> ();
		player = GameObject.FindGameObjectWithTag("Player");
		anim = GameObject.FindGameObjectWithTag ("Player").GetComponent<Animator> ();
		playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
		canClimbingDown = false;
	}

	void Start()
	{
		gravity = 1.0f;
	}

	void FixedUpdate()
	{
		if(player.transform.position.y > top.bounds.size.y  + 1.0f && !canClimbingDown)
		{
			CheckTop ();
		}

	 	if(player.transform.position.y < top.bounds.size.y)
		{
			canClimbingDown = false;
		}

		if(player.transform.position.y > top.bounds.size.y + 1.0f && Input.GetKeyDown(KeyCode.DownArrow) )
		{
			ClimbDown();
		}

	}

	private void CheckTop()
	{
		playerController.onLadder = false;
		anim.SetBool("isClimbing", true);
		playerController.rb2D.gravityScale = gravity;
		top.isTrigger = false;
		canClimbingDown = true;
	}

	private void ClimbDown()
	{
		playerController.onLadder = true;
		top.isTrigger = true;

	}

}
