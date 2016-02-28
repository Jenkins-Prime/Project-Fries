using UnityEngine;
using System.Collections;

public class DestroyBlock : MonoBehaviour 
{
	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "Player") 
		{
			Destroy (gameObject);
		}
	}
}
