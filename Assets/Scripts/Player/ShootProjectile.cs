using UnityEngine;
using System.Collections;

public class ShootProjectile : MonoBehaviour {
	GameObject projectile;
	public GameObject[] projectileList;
	public Vector3 target;
	float curAngle;
	public float minAngle = 20f;
	public float maxAngle = 90f;
	public float initAngle = 45f;
	public float shootTorque = -15f;
	float curTime;
	Rigidbody2D rb2D;
	LineRenderer lr;

	// Use this for initialization
	void Start () {
		target = transform.right * 4;
		curAngle = initAngle;
		curTime = 0f;
		rb2D = GetComponent<Rigidbody2D> ();
		lr = GetComponent<LineRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (projectile == null) {
			if(Input.GetButton("Fire1") ) {
				curTime += Time.deltaTime;
				if(curTime > 0.2) {
					TargetModeEnter();
				}
			} else if (Input.GetButtonUp("Fire1")){
				SpawnProjectile(Random.Range(0, projectileList.Length));
				curAngle = initAngle;
				curTime = 0f;
			}
		}
	}

	void TargetModeEnter() {
		//WIP
		lr.SetVertexCount(5);
		lr.SetPosition(0, transform.position);
		lr.SetPosition(1, transform.position + new Vector3(target.x/4, target.y+ (curAngle*Mathf.Deg2Rad)/2, target.z));
		lr.SetPosition(2, transform.position + new Vector3(target.x/2, target.y+ (curAngle*Mathf.Deg2Rad), target.z));
		lr.SetPosition(3, transform.position + new Vector3(target.x*3/4, target.y+ (curAngle*Mathf.Deg2Rad)/2, target.z));
		lr.SetPosition(4, transform.position + target);
	}

	void SpawnProjectile(int i) {
		projectile = (GameObject)Instantiate(projectileList[i], transform.position, Quaternion.identity);
		projectile.transform.parent = transform; //set the parent as the player
		projectile.GetComponent<Rigidbody2D> ().velocity = ProjectionVelocity.Calculate (target, curAngle) + rb2D.velocity;
		projectile.GetComponent<Rigidbody2D> ().AddTorque (shootTorque);
		Destroy(projectile, 3);
	}
}
