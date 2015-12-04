using UnityEngine;
using System.Collections;

public class ShootProjectile : MonoBehaviour {
	GameObject projectile;
	public GameObject[] projectileList;
	public float projectileDistance = 4f;
	public float shootAngle = 30f;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown (KeyCode.F))
		{
			SpawnProjectile(Random.Range(0, projectileList.Length));
		}
	}

	void SpawnProjectile(int i) {
		projectile = (GameObject)Instantiate(projectileList[i], transform.position, Quaternion.identity);
		projectile.transform.parent = transform; //set the parent as the player
		projectile.GetComponent<Rigidbody2D>().velocity = BallisticVelocity(projectileDistance, shootAngle);
		Destroy(projectile, 3);
	}

	//Need to add a param for including the player velocity
	Vector3 BallisticVelocity(float length, float angle) {
		float a = angle * Mathf.Deg2Rad;  // convert angle to radians
		Vector3 dir = new Vector3(length, length * Mathf.Tan(a), 0); // set y to the elevation angle
		float vel = Mathf.Sqrt(length * Physics.gravity.magnitude / Mathf.Sin(2 * a)); // calculate the velocity magnitude
		return vel * dir.normalized;
	}
}
