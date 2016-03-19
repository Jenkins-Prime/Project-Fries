using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PickupMoney : MonoBehaviour 
{
	public AudioClip pickUpSoundEffect;
	private int money;
	private GameController gameController;
	private Text points;
	private Text displayPoints;
	private bool hasCollected;

	void Awake()
	{
		gameController = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameController> ();
		points = GameObject.FindGameObjectWithTag ("Points").transform.GetChild (1).GetComponent<Text> ();
		displayPoints = gameObject.transform.GetChild (0).GetComponent<Text> ();


	}

	void Start () 
	{
		money = 100;
		hasCollected = false;
		displayPoints.text = "";
	}

	void Update()
	{
		if(hasCollected)
		{
			displayPoints.transform.position = new Vector3(displayPoints.transform.position.x, displayPoints.transform.position.y + 2.0f * Time.deltaTime, displayPoints.transform.position.z);
			StartCoroutine(ScrollPoints(1.0f));
		}
	}


	void OnTriggerEnter2D(Collider2D other) 
	{
		if (other.tag == "Player") 
		{
			gameController.GainMoney(money);
			points.text = gameController.money.ToString();
			GetComponent<SpriteRenderer>().enabled = false;
			GetComponent<CircleCollider2D>().enabled = false;
			hasCollected = true;
			AudioManager.instance.PlayAudio(pickUpSoundEffect);
			displayPoints.text = money.ToString();
		}
	}

	private IEnumerator ScrollPoints(float duration)
	{
		yield return new WaitForSeconds (duration);
		Destroy (gameObject);
	}
}
