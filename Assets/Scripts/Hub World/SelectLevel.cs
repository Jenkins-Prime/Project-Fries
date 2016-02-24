using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SelectLevel : MonoBehaviour 
{
	private Text level;
	private int currentLevel;
	private SelectWorld selectWorld;

	void Awake()
	{
		level = GameObject.FindGameObjectWithTag ("Level Select").GetComponent<Text> ();
		selectWorld = GameObject.FindGameObjectWithTag ("World Selector").GetComponent<SelectWorld> ();
	}

	void Start () 
	{
		currentLevel = 1;
	}

	void Update () 
	{
		if(currentLevel > 9)
		{
			currentLevel = 1;
		}

		if(currentLevel < 1)
		{
			currentLevel = 9;
		}

		if(currentLevel == 1 && Input.GetButtonDown("Submit"))
		{
			Application.LoadLevel(1);
		}

		LevelSelect ();
		level.text = currentLevel.ToString ();

	}

	private void LevelSelect()
	{
		if(Input.GetKeyDown(KeyCode.UpArrow))
		{
			currentLevel++;
		}

		if(Input.GetKeyDown(KeyCode.DownArrow))
		{
			currentLevel--;
		}
	}
}
