using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class MusicManager : MonoBehaviour {

	public AudioMixer mAudioMixer;

	public void Awake () {
		float fl;
		mAudioMixer.GetFloat("MusicVolume", out fl);
	}

}
