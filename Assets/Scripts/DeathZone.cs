using UnityEngine;
using System.Collections;

public class DeathZone : MonoBehaviour 
{
	public GameObject playerObject;
	public AudioClip respawnSoundEffect;

	private GameController gameController;
	private GameObject player;
	private GameObject playerCamera;
	private GameObject spawnPoint;
	private GameObject cameraPosition;
	private bool isDead;
	private CameraController cameraController;

	void Awake()
	{
		gameController = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameController> ();
		player = GameObject.FindGameObjectWithTag("Player");
		playerCamera = GameObject.FindGameObjectWithTag("MainCamera");
		cameraPosition = GameObject.FindGameObjectWithTag("MainCamera");
		spawnPoint = GameObject.FindGameObjectWithTag("Spawn Point");
	}

	void Start()
	{
		isDead = false;
	}

	void Update()
	{
		if(isDead)
		{
			playerCamera.transform.position = Vector3.Lerp(playerCamera.transform.position, new Vector3(spawnPoint.transform.position.x + 10.0f, spawnPoint.transform.position.y, spawnPoint.transform.position.z), 5.0f * Time.deltaTime);
			player.transform.position = new Vector3(spawnPoint.transform.position.x, 1.0f, 0.0f);
			StartCoroutine(Respawn (3.0f));
			player.SetActive(true);
			isDead = false;
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Player")
		{
			player.SetActive(false);
			isDead = true;
			AudioManager.instance.PlayAudio(respawnSoundEffect);
		}
		else
		{
			isDead = false;
		}
	}

	private IEnumerator Respawn (float duration)
	{
		yield return new WaitForSeconds(duration);

	}
}
