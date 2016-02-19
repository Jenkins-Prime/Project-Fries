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
	private PlayerController playerController;
	private SpriteRenderer speechBubble;
	private Text dialogueText;
	private Image endOfDialogue;
	private float letterPause;
	private bool isShowing;
	private bool isTextComplete;
	private GameObject npc;
	private GameObject player;
	private GameObject canvas;

	private Toggle slow;
	private Toggle fast;
	private Toggle faster;

	void Awake()
	{
		manager = GameObject.FindGameObjectWithTag ("Game UI").GetComponent<UIManager> ();
		speechBubble = gameObject.transform.GetChild (0).GetComponent<SpriteRenderer> ();
		dialogueText = GameObject.FindGameObjectWithTag ("Game UI").transform.GetChild (0).GetChild (0).GetComponent<Text> ();
		endOfDialogue = GameObject.FindGameObjectWithTag ("Game UI").transform.GetChild (0).GetChild (1).GetComponent<Image> ();
		player = GameObject.FindGameObjectWithTag("Player");
		playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
		canvas = GameObject.FindGameObjectWithTag("Game UI");
		slow = GameObject.FindGameObjectWithTag ("Dialogue Slow").GetComponent<Toggle> ();
		fast = GameObject.FindGameObjectWithTag ("Dialogue Fast").GetComponent<Toggle> ();
		faster = GameObject.FindGameObjectWithTag ("Dialogue Faster").GetComponent<Toggle> ();

	}

	void Start()
	{
		speechBubble.enabled = false;
		letterPause = 0.1f;
		isShowing = false;
		isTextComplete = false;
		endOfDialogue.enabled = false;
		slow.isOn = true;
		fast.isOn = false;
		faster.isOn = false;
	}

	// Update is called once per frame
	void Update () 
	{
		canvas.transform.position = new Vector3 (player.transform.position.x - 3.0f, player.transform.position.y + 1.0f, player.transform.position.z);

		if(Vector3.Distance(player.transform.position, transform.position) < 1.0f)
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
		}
			
		if(isTextComplete && Input.GetButtonDown("Submit") && inRange)
		{
			playerController.moveSpeed = 5.0f;
			playerController.jumpHeight = 10.0f;
			player.GetComponent<Animator>().enabled = true;
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

			if(slow.isOn)
			{
				yield return new WaitForSeconds(letterPause);
			}
			else if(fast.isOn)
			{
				yield return new WaitForSeconds(letterPause * 0.2f);
			}
			else if(faster.isOn)
			{
				yield return new WaitForSeconds(letterPause * 0.01f);
			}

		}
	}

	private void ReadFile()
	{
		FileStream stream2 = new FileStream (Application.dataPath + "/Dialogue/Dialogue" + ID + ".txt", FileMode.Open, FileAccess.Read);
			
			using (StreamReader reader2 = new StreamReader(stream2, Encoding.UTF8))
			{
				dialogue = reader2.ReadToEnd();
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
			playerController.moveSpeed = 0.0f;
			playerController.jumpHeight = 0.0f;
			player.GetComponent<Animator>().enabled = false;
		}

	}

}
