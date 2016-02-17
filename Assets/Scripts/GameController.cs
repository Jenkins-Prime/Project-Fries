using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
	public Image[] lives;
	public Image[] hunger;
	float currentHunger;
	public float maxHunger = 5.0f;
	int currentLives;
	public int maxLives = 3;
	int money;
	public int maxMoney = 10000;

	private float depleteRate;

	// Use this for initialization
	void Start () {
		currentHunger = maxHunger;
		currentLives = maxLives;
		money = 0;
		depleteRate = 0.1f * Time.deltaTime; 

	}

	void Update()
	{
		StartCoroutine ("LoseHealth");
	}
		
	public void GainHunger(int amount) 
	{
		currentHunger += amount;

		if(currentHunger >= hunger.Length)
		{
			currentHunger = hunger.Length;
		}

		for(int index = 0; index < currentHunger; index++)
		{
			hunger[index].enabled = true;
		}
	}
	
	public void LoseHunger(float amount) 
	{
		currentHunger -= amount;

		float temp = currentHunger + amount;
		
		for(int index = (int)currentHunger; index < temp; index++)
		{
			hunger[index].enabled = false;
		}

		if (currentHunger < 1.0f) 
		{
			Die();

			for(int index = 0; index < maxHunger; index++)
			{
				hunger[index].enabled = true;
			}

		}
	}
	
	public void GainLife(int amount) 
	{
		currentLives += amount;

		if (currentLives > maxLives) 
		{
			currentLives = maxLives;
		}

		for(int index = 0; index < currentLives; index++)
		{
			lives[index].enabled = true;

		}

		GainHunger (5);

	}
	
	public void LoseLife(int amount) 
	{
		currentLives -= amount;

		int temp = currentLives + amount;

		for(int index = currentLives; index < temp; index++)
		{
			lives[index].enabled = false;
		}

		currentHunger = maxHunger;

		if (currentLives < 1) 
		{
			GameOver();
		}
	}

	public void GainMoney(int amount) {
		money += amount;
		if (money > maxMoney)
			money = maxMoney;
	}
	
	public void LoseMoney(int amount) {
		money -= amount;
		if (money < 0)
			money = 0;
	}
	
	public void Die() 
	{
		LoseLife (1);
		Debug.Log ("Respawn");
	}
	
	public void GameOver() 
	{
		Debug.Log ("Game Over!");
	}

	private IEnumerator LoseHealth()
	{
		if(currentHunger >= maxHunger)
		{
			yield return new WaitForSeconds(1.0f);
		}
		LoseHunger(depleteRate);
	}
}
