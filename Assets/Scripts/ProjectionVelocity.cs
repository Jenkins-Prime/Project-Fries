using UnityEngine;
using System.Collections;

public static class ProjectionVelocity {

	public static Vector2 Calculate(Vector3 dir, float angle) {
		dir.y = 0;
		float length = dir.magnitude;
		float a = angle * Mathf.Deg2Rad;  // convert angle to radians
		dir = new Vector3(dir.x, length * Mathf.Tan(a), 0); // set y to the elevation angle
		float vel = Mathf.Sqrt(length * Physics.gravity.magnitude / Mathf.Sin(2 * a)); // calculate the velocity magnitude
		return vel * dir.normalized;
	}
}
