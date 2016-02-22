using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GameMenuManager : MonoBehaviour
{
	public GameObject menuPanel;
	public GameObject optionsPanel;

	private bool isShowing;
	private ShootProjectile projectile;


	void Awake()
	{
		projectile = GameObject.FindGameObjectWithTag ("Player").GetComponent<ShootProjectile>();
	}

	void Start()
	{
		menuPanel.SetActive (false);
		optionsPanel.SetActive (false);
	}

	void Update()
	{
		if(Input.GetButtonDown("Cancel"))
		{
			isShowing = !isShowing;
		}

		if(isShowing)
		{
			ShowGameWindow();
		}
		else
		{
			HideGameWindow();
		}
	}

	public void ShowGameWindow()
	{
		menuPanel.SetActive(true);
		projectile.enabled = false;

	}

	public void HideGameWindow()
	{
		menuPanel.SetActive(false);
		//projectile.enabled = true;
	}

	public void ShowOptionsWindow()
	{
		optionsPanel.SetActive (true);
	}

	public void HideOptionsWindow()
	{
		optionsPanel.SetActive (false);
	}

	public void ShowOptions()
	{
		optionsPanel.SetActive (true);
		isShowing = false;
		projectile.enabled = false;
	}

	public void CloseOptions()
	{
		HideOptionsWindow ();
		projectile.enabled = false;

	}
}
