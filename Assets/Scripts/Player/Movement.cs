using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour 
{
	public float gravity = 10.0f;
	public float speed = 1.0f;
	public float jumpHeight = 20.0f;

	private Rigidbody2D playerRB;
	private Animator anim;

	// Use this for initialization
	void Start () 
	{
		playerRB = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		Move (Input.GetAxis ("Horizontal"), speed);

		if(Input.GetButtonDown("Jump"))
		{
			Jump();
		}


	}

	private void Move(float horizontal, float speed)
	{
		if(horizontal != 0.0f)
		{
			playerRB.velocity = new Vector2 (horizontal * speed, playerRB.velocity.y - gravity);
			anim.speed = 1;
		}
		else
		{
			anim.speed = 0;
		}

	}

	private void Jump()
	{
		playerRB.velocity = new Vector2 (0.0f, jumpHeight);
	}	
}
