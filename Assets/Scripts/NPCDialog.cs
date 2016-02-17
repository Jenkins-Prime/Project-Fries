using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;
using System.Text;

public class NPCDialog : MonoBehaviour 
{
	public int ID;

	public string dialogue;
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
	}

	void Start()
	{
		speechBubble.enabled = false;
		letterPause = 0.1f;
		isShowing = false;
	}

	// Update is called once per frame
	void Update () 
	{
		if(inRange && Input.GetButtonDown("Submit") && !isShowing)
		{
			manager.ShowDialogue();
			StartCoroutine("DisplayDialogue");
			isShowing = true;

		}

		if(!inRange)
		{
			manager.HideDialogue();
			StopCoroutine("DisplayDialogue");
			dialogueText.text = "";
			isShowing = false;
		}

	}

	private IEnumerator DisplayDialogue()
	{
		foreach(char letter in dialogue.ToCharArray())
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

	private void ReadFile()
	{
		FileStream stream = new FileStream (Application.dataPath + "/Dialogue/Dialogue.txt", FileMode.Open, FileAccess.Read);
		
		using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
		{
			dialogue = reader.ReadToEnd();
		}
	}
	
	void OnTriggerEnter2D(Collider2D other) 
	{
		if (other.tag == "Player") 
		{
			inRange = true;
			speechBubble.enabled = true;
			ReadFile ();
		}
	}

	void OnTriggerExit2D(Collider2D other) 
	{
		if (other.tag == "Player") 
		{
			inRange = false;
			speechBubble.enabled = false;
			dialogue = "";

		}
	}
}
