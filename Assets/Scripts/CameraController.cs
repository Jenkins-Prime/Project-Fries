using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour 
{
	Transform player;
	public Vector2 minXY;
	public Vector2 maxXY;
	public float xOffset;
	public float yOffset;

	float vertExtend;
	float horExtend;
	float clampX;
	float clampY;

	// Use this for initialization
	void Start () 
	{
		player = GameObject.FindGameObjectWithTag("Player").transform;

		vertExtend = Camera.main.orthographicSize;
		horExtend = vertExtend * Screen.width / Screen.height;
	}

	void LateUpdate () 
	{	
		clampX = Mathf.Clamp (player.position.x + xOffset, minXY.x + horExtend, maxXY.x - horExtend);
		clampY = Mathf.Clamp (player.position.y + yOffset, minXY.y + vertExtend, maxXY.y - vertExtend);

		transform.position = new Vector3(clampX,clampY, transform.position.z);
	}

	void OnDrawGizmosSelected() {
		Gizmos.color = Color.red;

		Gizmos.DrawLine (new Vector3 (minXY.x,minXY.y, 0f), new Vector3 (maxXY.x, minXY.y, 0f));
		Gizmos.DrawLine (new Vector3 (maxXY.x,minXY.y, 0f), new Vector3 (maxXY.x, maxXY.y, 0f));
		Gizmos.DrawLine (new Vector3 (maxXY.x,maxXY.y, 0f), new Vector3 (minXY.x, maxXY.y, 0f));
		Gizmos.DrawLine (new Vector3 (minXY.x,maxXY.y, 0f), new Vector3 (minXY.x, minXY.y, 0f));
	}
}
