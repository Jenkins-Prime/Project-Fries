using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class SelectWorld : MonoBehaviour 
{

	public int currentWorld;
	[HideInInspector]
	public bool isWorldOne;
	[HideInInspector]
	public bool isWorldTwo;
	[HideInInspector]
	public bool isWorldThree;
	[HideInInspector]
	public bool isWorldFour;

	private GameObject worldOne;
	private GameObject worldTwo;
	private GameObject worldThree;
	private GameObject worldFour;
	

	private Text worldOneText;
	private Text worldTwoText;
	private Text worldThreeText;
	private Text worldFourText;

	private Image WorldOneBackground;
	private Image WorldTwoBackground;
	private Image WorldThreeBackground;
	private Image WorldFourBackground;
	private Image worldTwoLocked;
	private Image worldThreeLocked;
	private Image worldFourLocked;


	private bool isWorldTwoUnlocked;
	private bool isWorldThreeUnlocked;
	private bool isWorldFourUnlocked;


	

	void Awake()
	{
		worldOne = GameObject.FindGameObjectWithTag("World One");
		worldTwo = GameObject.FindGameObjectWithTag("World Two");
		worldThree = GameObject.FindGameObjectWithTag("World Three");
		worldFour = GameObject.FindGameObjectWithTag("World Four");

		WorldOneBackground = GameObject.FindGameObjectWithTag("World Names").transform.GetChild(0).GetComponent<Image>();
		WorldTwoBackground = GameObject.FindGameObjectWithTag("World Names").transform.GetChild(1).GetComponent<Image>();
		WorldThreeBackground = GameObject.FindGameObjectWithTag("World Names").transform.GetChild(2).GetComponent<Image>();
		WorldFourBackground = GameObject.FindGameObjectWithTag("World Names").transform.GetChild(3).GetComponent<Image>();
		worldOneText = GameObject.FindGameObjectWithTag("World Names").transform.GetChild(4).GetComponent<Text>();
		worldTwoText = GameObject.FindGameObjectWithTag("World Names").transform.GetChild(5).GetComponent<Text>();
		worldThreeText = GameObject.FindGameObjectWithTag("World Names").transform.GetChild(6).GetComponent<Text>();
		worldFourText = GameObject.FindGameObjectWithTag("World Names").transform.GetChild(7).GetComponent<Text>();

		worldTwoLocked = GameObject.FindGameObjectWithTag ("Locked World").transform.GetChild (0).GetComponent<Image> ();
		worldThreeLocked = GameObject.FindGameObjectWithTag ("Locked World").transform.GetChild (1).GetComponent<Image> ();
		worldFourLocked = GameObject.FindGameObjectWithTag ("Locked World").transform.GetChild (2).GetComponent<Image> ();

	}
	
	void Start () 
	{
		currentWorld = 1;
		worldOneText.text = "";
		worldTwoText.text = "";
		worldThreeText.text = "";
		worldFourText.text = "";
		isWorldOne = false;
		isWorldTwo = false;
		isWorldThree = false;
		isWorldFour = false;
		WorldOneBackground.enabled = false;
		WorldTwoBackground.enabled = false;
		WorldThreeBackground.enabled = false;
		WorldFourBackground.enabled = false;

		isWorldTwoUnlocked = false;
		isWorldThreeUnlocked = false;
		isWorldFourUnlocked = false;
	}

	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.A))
		{
			isWorldTwoUnlocked = true;
		}

		WorldSelect ();
		UnlockWorld ();
	}

	private void WorldSelect()
	{
		if (Input.GetKeyDown (KeyCode.RightArrow)) 
		{
			currentWorld++;
		}

		if (Input.GetKeyDown (KeyCode.LeftArrow)) 
		{
			currentWorld--;

		}

		if (currentWorld == 1) 
		{
			worldOneText.text = "Grassland";
			worldTwoText.text = "";
			worldThreeText.text = "";
			worldFourText.text = "";
			isWorldOne = true;
			isWorldTwo = false;
			isWorldThree = false;
			isWorldFour = false;

			gameObject.transform.position = new Vector3 (worldOne.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
			worldOne.transform.localScale = new Vector3(32, 32, 0);
			worldFour.transform.localScale = new Vector3(24, 24, 0);
			worldTwo.transform.localScale = new Vector3(24, 24, 0);
			WorldOneBackground.enabled = true;
			WorldTwoBackground.enabled = false;
			WorldThreeBackground.enabled = false;
			WorldFourBackground.enabled = false;
		} 
		else if (currentWorld == 2 && isWorldTwoUnlocked) 
		{
			worldOneText.text = "";
			worldTwoText.text = "Candy World";
			worldThreeText.text = "";
			worldFourText.text = "";

			isWorldOne = false;
			isWorldTwo = true;
			isWorldThree = false;
			isWorldFour = false;
			
			gameObject.transform.position = new Vector3 (worldTwo.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
			worldOne.transform.localScale = new Vector3(24, 24, 0);
			worldTwo.transform.localScale = new Vector3(32, 32, 0);
			worldThree.transform.localScale = new Vector3(24, 24, 0);
			WorldTwoBackground.enabled = true;
			WorldOneBackground.enabled = false;
			WorldThreeBackground.enabled = false;
			WorldFourBackground.enabled = false;
		} 
		else if (currentWorld == 3 && isWorldThreeUnlocked) 
		{
			worldOneText.text = "";
			worldTwoText.text = "";
			worldThreeText.text = "Sewer City";
			worldFourText.text = "";
			isWorldOne = false;
			isWorldTwo = false;
			isWorldThree = true;
			isWorldFour = false;
	
			gameObject.transform.position = new Vector3 (worldThree.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
			worldTwo.transform.localScale = new Vector3(24, 24, 0);
			worldThree.transform.localScale = new Vector3(32, 32, 0);
			worldFour.transform.localScale = new Vector3(24, 24, 0);
			WorldThreeBackground.enabled = true;
			WorldOneBackground.enabled = false;
			WorldTwoBackground.enabled = false;
			WorldFourBackground.enabled = false;
		} 
		else if (currentWorld == 4 && isWorldFourUnlocked)
		{
			worldOneText.text = "";
			worldTwoText.text = "";
			worldThreeText.text = "";
			worldFourText.text = "Abyss";
			isWorldOne = false;
			isWorldTwo = false;
			isWorldThree = false;
			isWorldFour = true;

			gameObject.transform.position = new Vector3 (worldFour.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
			worldThree.transform.localScale = new Vector3(24, 24, 0);
			worldFour.transform.localScale = new Vector3(32, 32, 0);
			WorldFourBackground.enabled = true;
			WorldOneBackground.enabled = false;
			WorldTwoBackground.enabled = false;
			WorldThreeBackground.enabled = false;

		}
		
		if (currentWorld > 4) 
		{
			currentWorld = 1;
		}
		
		if (currentWorld < 1) 
		{
			currentWorld = 4;
		}
	}

	private void UnlockWorld()
	{
		if(!isWorldTwoUnlocked)
		{
			worldTwoLocked.enabled = true;
		}
		else
		{
			worldTwoLocked.enabled = false;
		}
		
		if(!isWorldThreeUnlocked)
		{
			worldThreeLocked.enabled = true;
		}
		else
		{
			worldThreeLocked.enabled = false;
		}
		
		if(!isWorldFourUnlocked)
		{
			worldFourLocked.enabled = true;
		}
		else
		{
			worldFourLocked.enabled = false;
		}
	}
}
