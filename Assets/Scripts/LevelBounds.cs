using UnityEngine;
using System.Collections;

public enum LevelBoundry
{
	SMALL,
	MEDIUM,
	LARGE
}

public class LevelBounds : MonoBehaviour 
{
	private BoxCollider2D bounds;
	public LevelBoundry boundry;

	void Start () 
	{
		boundry = LevelBoundry.SMALL;
		bounds = GameObject.FindGameObjectWithTag ("Level Bounds").GetComponent<BoxCollider2D> ();
	}

	void Update () 
	{
		SelectLevelBounds ();
	}

	private void SelectLevelBounds()
	{
		switch(boundry)
		{
			case LevelBoundry.SMALL:
				bounds.size = new Vector2(50.0f, 20.0f);
				break;
			case LevelBoundry.MEDIUM:
				bounds.size = new Vector2(60.0f, 20.0f);
				break;
			case LevelBoundry.LARGE:
				bounds.size = new Vector2(100.0f, 20.0f);
				break;
		}
	}
}

