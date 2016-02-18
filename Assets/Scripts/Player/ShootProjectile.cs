using UnityEngine;
using System.Collections;

public class ShootProjectile : MonoBehaviour {
	GameObject projectile;
	public GameObject[] projectileList;
	float curTime;

	// Use this for initialization
	void Start () {
		curTime = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		curTime += Time.deltaTime;
		if(Input.GetButtonDown("Fire1")) {
			if(curTime > 0.5f) {
				SpawnProjectile(Random.Range(0, projectileList.Length));
				curTime = 0f;
			}
		}
	}


	void SpawnProjectile(int i) {
		Vector3 throwPos;
		if(transform.localScale.x > 0)
			throwPos = transform.position + transform.up + transform.right/2;
		else
			throwPos = transform.position + transform.up - transform.right/2;
		projectile = (GameObject)Instantiate(projectileList[i], throwPos, Quaternion.identity);
		//projectile.transform.parent = transform; //set the parent as the player
		Destroy(projectile, 3);
	}
}
