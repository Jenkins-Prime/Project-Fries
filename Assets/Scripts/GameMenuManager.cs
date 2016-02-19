using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class GameMenuManager : MonoBehaviour //IPointerClickHandler
{
	public GameObject menuPanel;
	public GameObject optionsPanel;

	private bool isShowing;

	void Start()
	{
		menuPanel.SetActive (false);
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
		Time.timeScale = 0.0f;
	}

	public void HideGameWindow()
	{
		menuPanel.SetActive(false);
		Time.timeScale = 1.0f;
	}

	public void ShowOptionsWindow()
	{
		optionsPanel.SetActive (true);
	}

	public void HideOptionsWindow()
	{
		optionsPanel.SetActive (false);
	}
}
