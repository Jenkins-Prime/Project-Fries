using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour 
{
	private bool isTimerOn;
	private float countDown;
	private float timer;
	private Text timerText;
	private GameController gameController;

	void Awake()
	{
		timerText = GetComponent<Text> ();
		gameController = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameController> ();
	}

	void Start () 
	{
		isTimerOn = true;
		countDown = 400.0f;
		timerText.text = countDown.ToString();
	}

	void Update () 
	{
		if(isTimerOn)
		{
			StartCoroutine(CountDown(100.0f));
		}
		else
		{
			gameController.GameOver();
		}

		if(countDown < 90.0f)
		{
			timerText.color = Color.red;
		}


	}

	private IEnumerator CountDown(float duration)
	{
		yield return new WaitForSeconds (duration  * Time.deltaTime);
		timer = countDown -= Time.deltaTime;
		timerText.text = timer.ToString ("f0");

		if(countDown <= 0.0f)
		{
			countDown = 0.0f;
			timerText.text = timer.ToString ("f0");
			isTimerOn = false;
		}
	}
}
