using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour 
{
	public float gravity;
	public float speed;
	public float jumpHeight;
	public GameObject[] projectile;
	public float projectileSpeed;


	private Rigidbody2D playerRB;
	private Animator anim;
	private GameObject spawnProjectile;
	private bool hasShot;
	private int randomPrefab;

	// Use this for initialization
	void Start () 
	{
		playerRB = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		spawnProjectile = GameObject.FindGameObjectWithTag ("Spawn Projectile");
		speed = 10.0f;
		gravity = 1.0f;
		jumpHeight = 20.0f;
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

	private void Shoot()
	{
		randomPrefab = Random.Range (0, projectile.Length);
		GameObject projectilePrefab = (GameObject)Instantiate (projectile[randomPrefab], spawnProjectile.transform.position, Quaternion.identity);
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
