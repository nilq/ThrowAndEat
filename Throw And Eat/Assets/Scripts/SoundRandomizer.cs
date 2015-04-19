/*
 * Will create its own audio source if none is present.
 * Can be called by other scripts to play random sound from array using the attatched audio source
*/
using UnityEngine;
using System.Collections;

public class SoundRandomizer : MonoBehaviour
{

	[Tooltip("Put the sounds to be chosen from into this array")]
	public AudioClip[]
		sounds;

	AudioSource speaker;

	// Use this for initialization
	void Start ()
	{
		try {
			speaker = gameObject.GetComponent<AudioSource> ();
			speaker.CompareTag("Fish");	//Simple way to provoke an error.
		} catch {
			speaker = gameObject.AddComponent<AudioSource> ();
			speaker.playOnAwake = false;
		}
	}
	
	public void playRandomClip ()
	{
		speaker.clip = sounds [Mathf.RoundToInt (Random.Range (0, sounds.Length))];
		speaker.Play ();
	}
}
