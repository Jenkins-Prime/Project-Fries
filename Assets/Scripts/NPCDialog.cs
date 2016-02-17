using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NPCDialog : MonoBehaviour 
{
	public string lines = "This is an example dialog text, fix me pls. :(";
	private bool inRange;
	private UIManager manager;
	private SpriteRenderer speechBubble;
	private Text dialogueText;
	private float letterPause;
	private bool isShowing;

	void Awake()
	{
		manager = GameObject.FindGameObjectWithTag ("Game UI").GetComponent<UIManager> ();
		speechBubble = gameObject.transform.GetChild (0).GetComponent<SpriteRenderer> ();
		dialogueText = GameObject.FindGameObjectWithTag ("Game UI").transform.GetChild (0).GetChild (0).GetComponent<Text> ();
		isShowing = false;
	}

	void Start()
	{
		speechBubble.enabled = false;
		letterPause = 0.1f;
		//dialogueText.text = lines;
	}
	// Update is called once per frame
	void Update () 
	{
		if(inRange && Input.GetButtonDown("Submit"))
		{
			manager.ShowDialogue();
			StartCoroutine("DisplayDialogue");
		}

		if(!inRange)
		{
			manager.HideDialogue();
			StopCoroutine("DisplayDialogue");
			dialogueText.text = "";
		}

	}

	private IEnumerator DisplayDialogue()
	{
		foreach(char letter in lines.ToCharArray())
		{
			dialogueText.text += letter;

			if(Input.GetButton("Jump"))
			{
				yield return new WaitForSeconds(letterPause * 0.09f);
			}
			else
			{
				yield return new WaitForSeconds(letterPause);
			}

		}
	}


	void OnTriggerEnter2D(Collider2D other) 
	{
		if (other.tag == "Player") 
		{
			inRange = true;
			speechBubble.enabled = true;
		}
	}

	void OnTriggerExit2D(Collider2D other) 
	{
		if (other.tag == "Player") 
		{
			inRange = false;
			speechBubble.enabled = false;

		}
	}
}
