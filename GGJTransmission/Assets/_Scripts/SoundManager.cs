using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour {

	[SerializeField]
	AudioSource[] mAudioSources;

	void Start () {
		
	}

	public void playPickupEnergy() {
		mAudioSources [0].Play ();
	}

	public void playHitByAsteroid() {
		mAudioSources [1].Play ();
	}

	public void swooshVelocity() {
		
	}
}
