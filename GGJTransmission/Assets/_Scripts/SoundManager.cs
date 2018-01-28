using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour {

	public AudioSource[] mAudioSources;

	public void playAsteroidHit () {
		mAudioSources[1].Play();
	}

	public void playEnergyPickup () {
		Debug.Log ("Energy pickup");
		mAudioSources [0].Play ();
	}

	public void playEnergyTransfer () {
		mAudioSources [2].Play ();
	}

}
