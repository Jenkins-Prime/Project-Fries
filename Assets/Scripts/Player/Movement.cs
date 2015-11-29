using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour 
{
	public float gravity;
	public float speed;
	public float jumpHeight;
	public GameObject projectile;
	public float projectileSpeed;


	private Rigidbody2D playerRB;
	private GameObject spawnProjectile;
	private bool hasShot;
	private float projectileDelay;

	// Use this for initialization
	void Start () 
	{
		playerRB = GetComponent<Rigidbody2D> ();
		spawnProjectile = GameObject.FindGameObjectWithTag ("Spawn Projectile");
		speed = 10.0f;
		gravity = 1.0f;
		jumpHeight = 20.0f;
		projectileDelay = 2.0f;
		hasShot = false;


	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		Move (Input.GetAxis ("Horizontal"), speed);

		if(Input.GetButtonDown("Jump"))
		{
			Jump();
		}

		if(Input.GetKeyDown (KeyCode.F) && !hasShot)
		{
			StartCoroutine(ProjectileDelay());
		}
	}

	private void Move(float horizontal, float speed)
	{
		playerRB.velocity = new Vector2 (horizontal * speed, playerRB.velocity.y - gravity);
	}

	private void Jump()
	{
		playerRB.velocity = new Vector2 (0.0f, jumpHeight);
	}

	private void Shoot()
	{
		GameObject projectilePrefab = (GameObject)Instantiate (projectile, spawnProjectile.transform.position, Quaternion.identity);
		projectilePrefab.name = "Projectile";
		Destroy (projectilePrefab, 1.0f);
	}

	private IEnumerator ProjectileDelay()
	{
		if(!hasShot)
		{
			Shoot ();
			hasShot = true;
		}
		yield return new WaitForSeconds (0.5f);
		hasShot = false;

	}
	



}
