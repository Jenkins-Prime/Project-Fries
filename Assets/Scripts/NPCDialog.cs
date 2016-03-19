using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;
using System.Text;

public class NPCDialog : MonoBehaviour 
{
	public int ID;
	public AudioClip dialogueSoundOpenEffect;
	public AudioClip dialogueSoundCloseEffect;


	private bool inRange;
	private string dialogue;
	private UIManager manager;
	private PlayerController playerController;
	private SpriteRenderer speechBubble;
	private SpriteRenderer blockInteration;
	private Text dialogueText;
	private Image endOfDialogue;
	private float letterPause;
	private float slowSpeed;
	private float fastSpeed;
	private bool isShowing;
	private bool isTextComplete;
	private bool hasInteracted;
	private GameObject npc;
	private GameObject player;
	private GameObject canvas;
	private Slider textSpeed;
	bool tagMode;
	bool enterTag;
	int skipLetter;
	string tagWord;
	string dialogueWord;
	int tmpLength;

	void Awake()
	{
		manager = GameObject.FindGameObjectWithTag ("Game UI").GetComponent<UIManager> ();
		speechBubble = gameObject.transform.GetChild (0).GetComponent<SpriteRenderer> ();
		blockInteration = gameObject.transform.GetChild (1).GetComponent<SpriteRenderer> ();
		dialogueText = GameObject.FindGameObjectWithTag ("Game UI").transform.GetChild (0).GetChild (0).GetComponent<Text> ();
		endOfDialogue = GameObject.FindGameObjectWithTag ("Game UI").transform.GetChild (0).GetChild (1).GetComponent<Image> ();
		player = GameObject.FindGameObjectWithTag("Player");
		playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
		canvas = GameObject.FindGameObjectWithTag("Game UI");
		textSpeed = GameObject.FindGameObjectWithTag ("Text Speed").GetComponent<Slider> ();

	}

	void Start()
	{
		speechBubble.enabled = false;
		blockInteration.enabled = false;
		isShowing = false;
		isTextComplete = false;
		endOfDialogue.enabled = false;
		hasInteracted = false;
		letterPause = 0.1f;
		slowSpeed = 0.5f;
		fastSpeed = 0.01f;
		tagMode = false;
		skipLetter = 0;
		textSpeed.value = 2;
	}

	// Update is called once per frame
	void Update () 
	{
		canvas.transform.position = new Vector3 (player.transform.position.x - 3.0f, player.transform.position.y + 1.0f, player.transform.position.z);

		if(hasInteracted)
		{
			blockInteration.enabled = true;
			speechBubble.enabled = false;
		}

		if(Vector3.Distance(player.transform.position, transform.position) < 1.0f && !hasInteracted)
		{
			speechBubble.enabled = true;
			inRange = true;

			if(Input.GetButtonDown("Submit") && inRange && !isTextComplete)
			{
				CanInteract();
			}

			if(Input.GetButtonDown("Submit") && !hasInteracted && isTextComplete)
			{
				playerController.moveSpeed = 5.0f;
				playerController.jumpHeight = 10.0f;
				player.GetComponent<Animator>().enabled = true;
				CloseDialogueBox();
			}

		}
		else
		{
			inRange = false;
			speechBubble.enabled = false;

		}
	}



	private void CloseDialogueBox()
	{
		manager.HideDialogue();
		StopCoroutine("DisplayDialogue");
		dialogueText.text = "";
		isShowing = true;
		hasInteracted = true;
		AudioManager.instance.PlayAudio(dialogueSoundCloseEffect);
	}

	private IEnumerator DisplayDialogue()
	{
		foreach(char letter in dialogue.ToCharArray())
		{
			if(skipLetter > 0) 
			{
				skipLetter--;
				continue;
			}
			if(letter == '<') 
			{
				if(tagMode) 
				{
					tagWord += "</color>";
					tagMode = false;
					enterTag = false;
					skipLetter = 7;
					continue;
				} 
				else 
				{
					tagWord = "<color=";
					tagMode = true;
					enterTag = true;
					skipLetter = 6;
					continue;
				}
			}
			if(tagMode) 
			{
				if(enterTag) 
				{
					if(letter == '>') 
					{
						enterTag = false;
						tmpLength = dialogueText.text.Length;
					}
					tagWord += letter;
					continue;
				} 
				else 
				{
					dialogueWord = tagWord + letter;
					dialogueText.text.Remove(tmpLength - 1);
					dialogueText.text += dialogueWord + "</color>";
				}
			} 
			else 
			{
				dialogueText.text += letter;
			}
			if(dialogueText.text.Contains("."))
			{
				isTextComplete = true;
				endOfDialogue.enabled = true;
				tagMode = false;
			}
			else
			{
				//isTextComplete = false;
				endOfDialogue.enabled = false;
			}

			if(textSpeed.value == 1)
			{
				yield return new WaitForSeconds(slowSpeed);

			}
			else if(textSpeed.value == 2)
			{
				yield return new WaitForSeconds(letterPause);
			}
			else
			{
				yield return new WaitForSeconds(fastSpeed);
			}

		}
	}

	private void ReadFile()
	{
		FileStream stream = new FileStream (Application.dataPath + "/StreamingAssets/Dialogue" + ID + ".txt", FileMode.Open, FileAccess.Read);
			
			using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
			{
				dialogue = reader.ReadToEnd();
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
			AudioManager.instance.PlayAudio(dialogueSoundOpenEffect);

		}

	}

}
