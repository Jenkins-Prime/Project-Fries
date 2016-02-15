using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
	public Image[] lives;
	int health;
	public int maxHealth = 3;
	int currentLives;
	public int maxLives = 3;
	int money;
	public int maxMoney = 10000;

	// Use this for initialization
	void Start () {
		health = maxHealth;
		currentLives = maxLives;
		money = 0;

	}

	void Update()
	{
		if(Input.GetKeyDown (KeyCode.H))
		{
			LoseLife(1);
		}
	}
		
	public void GainHealth(int amount) 
	{
		health += amount;
		if (health > maxHealth)
			health = maxHealth;
	}
	
	public void LoseHealth(int amount) {
		health -= amount;
		if (health < 1) {
			Die();
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

	}
	
	public void LoseLife(int amount) 
	{
		currentLives -= amount;

		int temp = currentLives + amount;

		for(int index = currentLives; index < temp; index++)
		{
			lives[index].enabled = false;
		}

		health = maxHealth;

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
	
	void Die() {
		Debug.Log ("Life Lost!");
		LoseLife (1);
	}
	
	void GameOver() 
	{
		Debug.Log ("Game Over!");
	}
}
