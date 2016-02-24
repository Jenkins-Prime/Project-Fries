using UnityEngine;
using System.Collections;


public class SelectWorld : MonoBehaviour 
{
	public GameObject levelSelectOne;
	public GameObject levelSelectTwo;
	public GameObject levelSelectThree;
	public GameObject levelSelectFour;

	[HideInInspector]
	public bool isWorldOne;
	[HideInInspector]
	public bool isWorldTwo;
	[HideInInspector]
	public bool isWorldThree;
	[HideInInspector]
	public bool isWorldFour;
	
	public int currentWorld;
	private GameObject worldOne;
	private GameObject worldTwo;
	private GameObject worldThree;
	private GameObject worldFour;

	void Awake()
	{
		worldOne = GameObject.FindGameObjectWithTag("World One");
		worldTwo = GameObject.FindGameObjectWithTag("World Two");
		worldThree = GameObject.FindGameObjectWithTag("World Three");
		worldFour = GameObject.FindGameObjectWithTag("World Four");
	}
	
	void Start () 
	{
		currentWorld = 1;
		levelSelectOne.SetActive (false);
		levelSelectTwo.SetActive (false);
		levelSelectThree.SetActive (false);
		levelSelectFour.SetActive (false);

		isWorldOne = false;
		isWorldTwo = false;
		isWorldThree = false;
		isWorldFour = false;
	}

	void Update () 
	{
		WorldSelect ();

	}

	private void WorldSelect()
	{
		if(Input.GetKeyDown(KeyCode.RightArrow))
		{
			currentWorld++;
		}

		if(Input.GetKeyDown(KeyCode.LeftArrow))
		{
			currentWorld--;

		}

		
		if (currentWorld == 1) 
		{

			if(Input.GetButtonDown ("Submit"))
			{
				levelSelectOne.SetActive (true);
				levelSelectTwo.SetActive (false);
				levelSelectThree.SetActive (false);
				levelSelectFour.SetActive (false);
			}
			
			gameObject.transform.position = new Vector3 (worldOne.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
		}
		else if (currentWorld == 2) 
		{
			if(Input.GetButtonDown ("Submit"))
			{
				levelSelectOne.SetActive (false);
				levelSelectTwo.SetActive (true);
				levelSelectThree.SetActive (false);
				levelSelectFour.SetActive (false);
			}
			
			gameObject.transform.position = new Vector3(worldTwo.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
		}
		else if (currentWorld == 3) 
		{
			if(Input.GetButtonDown ("Submit"))
			{
				isWorldThree = true;
				levelSelectOne.SetActive (false);
				levelSelectTwo.SetActive (false);
				levelSelectThree.SetActive (true);
				levelSelectFour.SetActive (false);
			}
			
			gameObject.transform.position = new Vector3(worldThree.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
		}
		else 
		{
			if(Input.GetButtonDown ("Submit"))
			{
				isWorldFour = true;
				levelSelectOne.SetActive (false);
				levelSelectTwo.SetActive (false);
				levelSelectThree.SetActive (false);
				levelSelectFour.SetActive (true);
			}
			
			gameObject.transform.position = new Vector3(worldFour.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
		}
		
		if(currentWorld > 4)
		{
			currentWorld = 1;
		}
		
		if(currentWorld < 1)
		{
			currentWorld = 4;
		}
	}
}
