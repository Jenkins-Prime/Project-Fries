using UnityEngine;
using System.Collections;

public class ShootProjectile : MonoBehaviour {
	GameObject projectile;
	public GameObject[] projectileList;
	public Vector3 target;
	float currentAngle;
	public float initialAngle = 30f;
	public float maxAngle = 80f;
	public float shootTorque = -15f;
	Rigidbody2D rb2D;

	// Use this for initialization
	void Start () {
		target = transform.right * 4;
		currentAngle = initialAngle;
		rb2D = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (projectile == null) {
			if(Input.GetButton("Fire1") ) {
				if(currentAngle < maxAngle) {
					currentAngle += 1;
				}
			} else if (Input.GetButtonUp("Fire1")){
				SpawnProjectile(Random.Range(0, projectileList.Length));
				currentAngle = initialAngle;
			}
		}
	}

	void SpawnProjectile(int i) {
		projectile = (GameObject)Instantiate(projectileList[i], transform.position, Quaternion.identity);
		projectile.transform.parent = transform; //set the parent as the player
		projectile.GetComponent<Rigidbody2D> ().velocity = ProjectionVelocity.Calculate (target, currentAngle) + rb2D.velocity;
		projectile.GetComponent<Rigidbody2D> ().AddTorque (shootTorque);
		Destroy(projectile, 3);
	}
}
