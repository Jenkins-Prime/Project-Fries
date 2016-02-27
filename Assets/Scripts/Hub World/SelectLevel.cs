using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SelectLevel : MonoBehaviour 
{
	public GameObject levelSelectOne;
	public GameObject levelSelectTwo;
	public GameObject levelSelectThree;
	public GameObject levelSelectFour;
	public bool[] isLevelComplete;
	

	
	private int currentLevel;
	private SelectWorld selectWorld;
	private Text levelOneSelector;
	private Text levelTwoSelector;
	private Text levelThreeSelector;
	private Text levelFourSelector;
	private Image lockedLevelIcon;
	private Image castleIcon;
	private Image bossIcon;
	private bool isLevelLocked;
	private Text greyOutLevelText;
	private Text greyOutText;


	void Awake()
	{
		selectWorld = GameObject.FindGameObjectWithTag ("World Selector").GetComponent<SelectWorld> ();
		levelOneSelector = GameObject.FindGameObjectWithTag ("LevelOneSelector").transform.GetChild (1).GetComponent<Text> ();
		levelTwoSelector = GameObject.FindGameObjectWithTag ("LevelTwoSelector").transform.GetChild (1).GetComponent<Text> ();
		levelThreeSelector = GameObject.FindGameObjectWithTag ("LevelThreeSelector").transform.GetChild (1).GetComponent<Text> ();
		levelFourSelector = GameObject.FindGameObjectWithTag ("LevelFourSelector").transform.GetChild (1).GetComponent<Text> ();
		lockedLevelIcon = GameObject.FindGameObjectWithTag ("LockedLevel").GetComponent<Image> ();
		castleIcon = GameObject.FindGameObjectWithTag ("Castle Icon").GetComponent<Image> ();
		bossIcon = GameObject.FindGameObjectWithTag ("Boss Icon").GetComponent<Image> ();
		greyOutLevelText = GameObject.Find ("Level").GetComponent<Text> ();
		greyOutText = GameObject.Find ("LevelText").GetComponent<Text> ();


	}

	void Start () 
	{
		currentLevel = 1;
		levelSelectOne.SetActive (false);
		levelSelectTwo.SetActive (false);
		levelSelectThree.SetActive (false);
		levelSelectFour.SetActive (false);
		levelOneSelector.text = currentLevel.ToString ();
		levelTwoSelector.text = currentLevel.ToString ();
		levelThreeSelector.text = currentLevel.ToString ();
		levelFourSelector.text = currentLevel.ToString ();
		lockedLevelIcon.enabled = false;
		isLevelLocked = true;
		castleIcon.enabled = false;
		bossIcon.enabled = false;

		for(int index = 0; index < isLevelComplete.Length; index++)
		{
			isLevelComplete[index] = false;
		}
	}

	void Update () 
	{

		if(isLevelLocked)
		{
			lockedLevelIcon.enabled = true;
			greyOutLevelText.color = Color.grey;
			greyOutText.color = Color.grey;
		}
		else
		{
			lockedLevelIcon.enabled = false;
			greyOutLevelText.color = Color.black;
			greyOutText.color = Color.black;

		}

		if(currentLevel > 10)
		{
			currentLevel = 1;
		}

		if(currentLevel < 1)
		{
			currentLevel = 10;
		}

		UnlockLevels ();
		ShowLevels ();
		LevelSelect ();
		levelOneSelector.text = currentLevel.ToString ();
		levelTwoSelector.text = currentLevel.ToString ();
		levelThreeSelector.text = currentLevel.ToString ();
		levelFourSelector.text = currentLevel.ToString ();
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

	private void ShowLevels()
	{
		if (Input.GetButtonDown ("Submit") && selectWorld.isWorldOne) 
		{
			levelSelectOne.SetActive (true);
			levelSelectTwo.SetActive (false);
			levelSelectThree.SetActive (false);
			levelSelectFour.SetActive (false);
		}

		if(Input.GetButtonDown("Submit") && selectWorld.isWorldTwo)
		{
			levelSelectOne.SetActive(false);
			levelSelectTwo.SetActive(true);
			levelSelectThree.SetActive (false);
			levelSelectFour.SetActive(false);
		}

		if(Input.GetButtonDown("Submit") && selectWorld.isWorldThree)
		{
			levelSelectOne.SetActive(false);
			levelSelectTwo.SetActive(false);
			levelSelectThree.SetActive (true);
			levelSelectFour.SetActive(false);
		}

		if(Input.GetButtonDown("Submit") && selectWorld.isWorldFour)
		{
			levelSelectOne.SetActive(false);
			levelSelectTwo.SetActive(false);
			levelSelectThree.SetActive (false);
			levelSelectFour.SetActive(true);
		}
	}
	

	private void UnlockLevels()
	{
		if(currentLevel == 1 && selectWorld.isWorldOne)
		{
			isLevelLocked = false;
			
			if(Input.GetKeyDown(KeyCode.Space))
			{
				Application.LoadLevel("testscene");
			}
		}
		else if(currentLevel == 2 && isLevelComplete[0] && selectWorld.isWorldOne)
		{
			isLevelLocked = false;
		}
		else if(currentLevel == 3 && isLevelComplete[1] && selectWorld.isWorldOne)
		{
			isLevelLocked = false;
		}
		else if(currentLevel == 4 && isLevelComplete[2] && selectWorld.isWorldOne)
		{
			isLevelLocked = false;
		}
		else if(currentLevel == 5 && isLevelComplete[3] && selectWorld.isWorldOne)
		{
			castleIcon.enabled = true;
			isLevelLocked = false;
		}
		else if(currentLevel == 6 && isLevelComplete[4] && selectWorld.isWorldOne)
		{
			isLevelLocked = false;
		}
		else if(currentLevel == 7 && isLevelComplete[5] && selectWorld.isWorldOne)
		{
			isLevelLocked = false;
		}
		else if(currentLevel == 8 && isLevelComplete[6] && selectWorld.isWorldOne)
		{
			isLevelLocked = false;
		}
		else if(currentLevel == 9 && isLevelComplete[7] && selectWorld.isWorldOne)
		{
			isLevelLocked = false;
		}
		else if(currentLevel == 10 && isLevelComplete[8] && selectWorld.isWorldOne)
		{
			bossIcon.enabled = true;
			isLevelLocked = false;
		}
		else
		{
			castleIcon.enabled = false;
			bossIcon.enabled = false;
			isLevelLocked = true;

			if(isLevelLocked && Input.GetButtonDown("Jump"))
			{
				Debug.Log ("Level Locked!");
			}
		}
	}
}
