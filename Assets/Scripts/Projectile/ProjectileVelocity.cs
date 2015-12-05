using UnityEngine;
using System.Collections;

public class ProjectileVelocity : MonoBehaviour 
{
	private Rigidbody2D rb2d;
	private float projectileSpeed;
	// Use this for initialization
	void Start () 
	{
		rb2d = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		Velocity (Input.GetAxis("Horizontal"), projectileSpeed);
	}

	private void Velocity(float horizontal, float speed)
	{
		rb2d.AddForce (Vector2.right * 100.0f);
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.gameObject.tag == "Enemy")
		{

		}
	}
}
