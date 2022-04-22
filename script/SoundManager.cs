using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

	public static AudioClip playerJump;
	public static AudioClip endGame;
	public static AudioClip bee;
	public static AudioClip pop;
	public static AudioSource audioSrc;

	void Start () {
		playerJump = Resources.Load<AudioClip> ("playerJump");
		endGame = Resources.Load<AudioClip> ("endGame");
		bee = Resources.Load<AudioClip> ("bee");
		pop = Resources.Load<AudioClip> ("pop");
		audioSrc = GetComponent<AudioSource> ();
	}

	public static void PlaySound (string sonido){
		switch(sonido){
		case "playerJump":
			audioSrc.PlayOneShot (playerJump);
			break;
		case "endGame":
			audioSrc.PlayOneShot (endGame);
			break;
		case "bee":
			audioSrc.PlayOneShot (bee);
			break;
		case "pop":
			audioSrc.PlayOneShot (pop);
			break;
		}
	}

}
