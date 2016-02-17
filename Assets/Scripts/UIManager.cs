using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour 
{
	public GameObject dialogueUI;

	// Use this for initialization
	void Start()
	{
		dialogueUI.SetActive (false);
	}

	public void ShowDialogue()
	{
		dialogueUI.SetActive (true);
	}

	public void HideDialogue()
	{
		dialogueUI.SetActive (false);
	}
}
