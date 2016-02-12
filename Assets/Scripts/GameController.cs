using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	int health;
	public int maxHealth = 3;
	int lives;
	public int maxLives = 3;
	int money;
	public int maxMoney = 10000;

	// Use this for initialization
	void Start () {
		health = maxHealth;
		lives = maxLives;
		money = 0;
	}
		
	public void GainHealth(int amount) {
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
	
	public void GainLife(int amount) {
		lives += amount;
		if (lives > maxLives) {
			lives = maxLives;
		}
	}
	
	public void LoseLife(int amount) {
		lives -= amount;
		health = maxHealth;
		if (lives < 1) {
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
	
	void GameOver() {
		Debug.Log ("Game Over!");
	}
}
