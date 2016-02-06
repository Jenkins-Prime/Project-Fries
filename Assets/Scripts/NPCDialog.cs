using UnityEngine;
using System.Collections;

public class NPCDialog : MonoBehaviour {
	bool dialogEnabled;
	public string dialogText = "This is an example dialog text, fix me pls. :(";

	// Use this for initialization
	void Start () {
		dialogEnabled = false;
		transform.GetChild(0).gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		if (dialogEnabled) {
			if(Input.GetButtonDown("Submit")) {
				//Disable Movement
				//Pause Time, Maybe?
				//Show Dialog
				//Import from file
				Debug.Log (dialogText);
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Player") {
			dialogEnabled = true;
			transform.GetChild(0).gameObject.SetActive(true);
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if (other.tag == "Player") {
			dialogEnabled = false;
			transform.GetChild(0).gameObject.SetActive(false);
		}
	}
}
