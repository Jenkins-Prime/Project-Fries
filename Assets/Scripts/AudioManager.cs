using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour 
{
	public static AudioManager instance = null;
	public AudioSource music;
	public AudioSource soundEffects;

	void Awake()
	{
		if(instance == null)
		{
			instance = this;
		}
		else if(instance != this)
		{
			Destroy(gameObject);
		}

		DontDestroyOnLoad (gameObject);
	}
	

	public void PlayAudio(AudioClip audio)
	{
		soundEffects.clip = audio;
		soundEffects.Play ();
	}

	public void PlayDelayAudio(AudioClip audio)
	{
		soundEffects.clip = audio;
		soundEffects.PlayDelayed (0.1f);
	}
}
