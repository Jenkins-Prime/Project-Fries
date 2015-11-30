using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour 
{
	private Transform player;
	private float minleft;
	private float maxRight;
	// Use this for initialization
	void Start () 
	{
		player = GameObject.FindGameObjectWithTag("Player").transform;
		minleft = 0.23f;
		maxRight = 20.71f;
	}
	
	// Update is called once per frame
	void LateUpdate () 
	{
		transform.position = new Vector3 (Mathf.Clamp (player.position.x, minleft, maxRight), transform.position.y, transform.position.z);

	}
}
