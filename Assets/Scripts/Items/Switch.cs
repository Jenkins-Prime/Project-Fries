using UnityEngine;
using System.Collections;

public class Switch : MonoBehaviour 
{
	public GameObject spring;
	public GameObject block;
	public GameObject heavyBlock;
	private Animator anim;
	private PlayerController playerController;

	
	void Awake()
	{
		anim = GetComponent<Animator> ();
		playerController = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerController> ();

	}

	void Start()
	{
		spring.SetActive (false);
		block.SetActive (false);
		heavyBlock.SetActive (false);
	}

	
	void OnCollisionEnter2D(Collision2D col)
	{
		if(col.gameObject.tag == "Player" && playerController.transform.position.y > 1.7f)
		{
			anim.SetBool("hasPressed", true);
			gameObject.GetComponent<EdgeCollider2D>().isTrigger = true;
			spring.SetActive(true);
			block.SetActive (true);
			heavyBlock.SetActive (true);
		}
	}
	

}
