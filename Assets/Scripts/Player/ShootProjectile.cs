using UnityEngine;
using System.Collections;

public class ShootProjectile : MonoBehaviour {
	GameObject projectile;
	public GameObject[] projectileList;
	public Vector3 target;
	public float shootAngle = 30f;

	// Use this for initialization
	void Start () {
		target = transform.right * 4;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown (KeyCode.F) && projectile == null)
		{
			SpawnProjectile(Random.Range(0, projectileList.Length));
		}
	}

	void SpawnProjectile(int i) {
		projectile = (GameObject)Instantiate(projectileList[i], transform.position, Quaternion.identity);
		projectile.transform.parent = transform; //set the parent as the player
		projectile.GetComponent<Rigidbody2D> ().velocity = ProjectionVelocity.Calculate (target, shootAngle);
		Destroy(projectile, 3);
	}
}
