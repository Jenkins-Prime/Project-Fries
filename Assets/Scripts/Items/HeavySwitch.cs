using UnityEngine;
using System.Collections;

public class HeavySwitch : MonoBehaviour 
{
	public GameObject prefab;

	private Animator anim;
	private PlayerController playerController;
	private Rigidbody2D rbody2D;
	private GameObject spawnObject;


	
	
	void Awake()
	{
		anim = GetComponent<Animator> ();
		playerController = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerController> ();
		rbody2D = GameObject.FindGameObjectWithTag ("Heavy Block").GetComponent<Rigidbody2D> ();
		spawnObject = GameObject.Find ("Spawn");
		
	}
	
	
	void OnCollisionEnter2D(Collision2D col)
	{
		if(col.gameObject.tag == "Heavy Block" && rbody2D.mass > 1)
		{
			anim.SetBool("hasPressed", true);
			gameObject.GetComponent<EdgeCollider2D>().isTrigger = true;
			GameObject go = (GameObject)Instantiate(prefab, spawnObject.transform.position, spawnObject.transform.rotation);
			go.name = "Secret";

		}
	}
	
	void OnTriggerExit2D()
	{
		//anim.SetBool("hasPressed", false);
	}
}
