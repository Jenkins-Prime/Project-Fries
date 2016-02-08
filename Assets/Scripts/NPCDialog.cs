using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NPCDialog : MonoBehaviour {
	bool canShowDialog;
	bool dialogEnabled;
	Image dialogBox;
	Text dialogText;
	public string lines = "This is an example dialog text, fix me pls. :(";

	// Use this for initialization
	void Start () {
		canShowDialog = false;
		dialogEnabled = false;
		transform.GetChild(0).gameObject.SetActive(false);
		dialogBox = GameObject.FindGameObjectWithTag ("DialogBox").GetComponent<Image>();
		dialogText = GameObject.FindGameObjectWithTag ("DialogText").GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		if (canShowDialog) {
			if(Input.GetButtonDown("Submit")) {
				if(!dialogEnabled) {
					Time.timeScale = 0; //"Raw" method of pausing the game, not sure if it's good practice to use.
					//TO DO: Import from file
					dialogText.text = lines;
					dialogBox.enabled = true;
					dialogText.enabled = true;
					dialogEnabled = true;
				} else if(dialogEnabled) {
					Time.timeScale = 1; //Unpause
					dialogBox.enabled = false;
					dialogText.enabled = false;
					dialogEnabled = false;
				}
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Player") {
			canShowDialog = true;
			transform.GetChild(0).gameObject.SetActive(true);
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if (other.tag == "Player") {
			canShowDialog = false;
			transform.GetChild(0).gameObject.SetActive(false);
		}
	}
}
