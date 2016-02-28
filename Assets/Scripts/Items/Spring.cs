using UnityEngine;
using System.Collections;

public class Spring : MonoBehaviour 
{
	private Animator anim;
	private Rigidbody2D force;
	private PlayerController playerController;
	private float bounceHeight;

	void Awake()
	{
		anim = GetComponent<Animator> ();
		force = GameObject.FindGameObjectWithTag ("Player").GetComponent<Rigidbody2D> ();
		playerController = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerController> ();

	}

	void Start()
	{
		bounceHeight = 20.0f;
	}

	void Update()
	{

	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.tag == "Player" && playerController.transform.position.y > 1.2f)
		{
			playerController.rb2D.velocity = new Vector2(playerController.rb2D.velocity.x, bounceHeight);
			anim.SetBool("isTouching", true);
		}
	}

	void OnTriggerExit2D()
	{
		anim.SetBool("isTouching", false);
	}
}
