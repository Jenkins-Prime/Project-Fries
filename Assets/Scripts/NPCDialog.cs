using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;
using System.Text;

public class NPCDialog : MonoBehaviour 
{
	public int ID;

	private bool inRange;
	private string dialogue;
	private UIManager manager;
	private SpriteRenderer speechBubble;
	private Text dialogueText;
	private Image endOfDialogue;
	private float letterPause;
	private bool isShowing;
	private bool isTextComplete;
	private GameObject npc;
	private GameObject player;
	private GameObject canvas;
	

	void Awake()
	{
		manager = GameObject.FindGameObjectWithTag ("Game UI").GetComponent<UIManager> ();
		speechBubble = gameObject.transform.GetChild (0).GetComponent<SpriteRenderer> ();
		dialogueText = GameObject.FindGameObjectWithTag ("Game UI").transform.GetChild (0).GetChild (0).GetComponent<Text> ();
		endOfDialogue = GameObject.FindGameObjectWithTag ("Game UI").transform.GetChild (0).GetChild (1).GetComponent<Image> ();
		npc = GameObject.FindGameObjectWithTag("NPC");
		player = GameObject.FindGameObjectWithTag("Player");
		canvas = GameObject.FindGameObjectWithTag("Game UI");
	}

	void Start()
	{
		speechBubble.enabled = false;
		letterPause = 0.1f;
		isShowing = false;
		isTextComplete = false;
		endOfDialogue.enabled = false;
	}

	// Update is called once per frame
	void Update () 
	{
		canvas.transform.position = new Vector3 (player.transform.position.x - 1.0f, player.transform.position.y + 1.0f, player.transform.position.z);

		if(Vector3.Distance(player.transform.position, npc.transform.position) < 1.0f && npc.tag == "NPC")
		{
			speechBubble.enabled = true;
			inRange = true;

			if(Input.GetButtonDown("Submit"))
			{
				CanInteract();
			}
		}
		else
		{
			inRange = false;
			speechBubble.enabled = false;
			CloseDialogueBox();
		}
			
		if(isTextComplete && Input.GetButtonDown("Submit"))
		{
			CloseDialogueBox();
		}

	}

	private void CloseDialogueBox()
	{
		manager.HideDialogue();
		StopCoroutine("DisplayDialogue");
		dialogueText.text = "";
		isShowing = false;
	}

	private IEnumerator DisplayDialogue()
	{
		foreach(char letter in dialogue.ToCharArray())
		{
			dialogueText.text += letter;

			if(dialogueText.text.Contains(dialogue))
			{
				isTextComplete = true;
				endOfDialogue.enabled = true;
			}
			else
			{
				isTextComplete = false;
				endOfDialogue.enabled = false;
			}

			if(Input.GetButton("Submit"))
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
		if(ID == 0)
		{
			FileStream stream = new FileStream (Application.dataPath + "/Dialogue/Dialogue.txt", FileMode.Open, FileAccess.Read);
			
			using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
			{
				dialogue = reader.ReadToEnd();
			}
		}
		else if(ID == 1)
		{
			FileStream stream1 = new FileStream (Application.dataPath + "/Dialogue/Dialogue1.txt", FileMode.Open, FileAccess.Read);
			
			using (StreamReader reader1 = new StreamReader(stream1, Encoding.UTF8))
			{
				dialogue = reader1.ReadToEnd();
			}
		}
		else if(ID == 2)
		{
			FileStream stream2 = new FileStream (Application.dataPath + "/Dialogue/Dialogue2.txt", FileMode.Open, FileAccess.Read);
			
			using (StreamReader reader2 = new StreamReader(stream2, Encoding.UTF8))
			{
				dialogue = reader2.ReadToEnd();
			}
		}
	}

	private void CanInteract()
	{
		if(inRange && !isShowing)
		{
			manager.ShowDialogue();
			ReadFile();
			StartCoroutine("DisplayDialogue");
			isShowing = true;
			ID = Random.Range(0, 3);
		}
	}

}
