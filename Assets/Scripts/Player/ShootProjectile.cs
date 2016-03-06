using UnityEngine;
using System.Collections;

public class ShootProjectile : MonoBehaviour 
{
	GameObject projectile;
	public GameObject[] projectileList;
	public float fireRate = 1f;
	float curTime;


	void Start () 
	{
		curTime = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		curTime += Time.deltaTime;
		if(Input.GetButtonDown("Fire1")) {
			if(curTime > fireRate) {
				SpawnProjectile();
				curTime = 0f;
			}
		}
	}

	void SpawnProjectile() {
		Vector3 pos;
		Vector2 dir;

		if(Input.GetAxisRaw("Vertical") > 0) { //Throw up
			pos = transform.position + transform.up;
			dir = new Vector2(0, 1);
		} else if (Input.GetAxisRaw("Vertical") < 0) { //Throw down
			pos = transform.position;
			dir = new Vector2(0, -1);
		} else { //Horizontal throw
			if (transform.localScale.x > 0) { //Throw right
				pos = transform.position + transform.up + transform.right / 2;
				dir = new Vector2(1, 0);
			} else { //Throw left
				pos = transform.position + transform.up - transform.right / 2;
				dir = new Vector2(-1, 0);
			}
		}

		projectile = (GameObject)Instantiate (projectileList [Random.Range(0, projectileList.Length)], pos, Quaternion.identity);
		projectile.GetComponent<ProjectileController> ().moveDirection = dir;
		Destroy(projectile, 3);			
	}
}
