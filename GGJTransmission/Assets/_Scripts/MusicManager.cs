using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class MusicManager : MonoBehaviour {

	public AudioMixer mAudioMixer;
	public AudioMixerSnapshot[] mSnapshots;

	[Range(0.0f, 1.0f)]
	public float mIntensity;

	public void Awake () {
		StartCoroutine(checkIntensity (1.5f));
	}



	public float intensity {
		set {
			mIntensity = value;
		}
		get {
			return mIntensity;
		}
	}

	IEnumerator checkIntensity (float interval) {

		while (true) {
			if (mIntensity < 0.15) {
				//float[] w = { 1.0f, mIntensity / 0.2f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f };
				//mAudioMixer.TransitionToSnapshots(mSnapshots, w, 1.0f);
				mSnapshots [0].TransitionTo (1f);
			} else if (mIntensity < 0.35) {
				//float[] w = { 1.0f, 1.0f, mIntensity / 0.35f, 0.0f, 0.0f, 0.0f, 0.0f };
				//mAudioMixer.TransitionToSnapshots(mSnapshots, w, 1f);
				mSnapshots [1].TransitionTo (1f);
			} else if (mIntensity < 0.45) {
				//float[] w = { 1.0f, 1.0f, 1.0f, mIntensity / 0.45f, 0.0f, 0.0f, 0.0f };
				//mAudioMixer.TransitionToSnapshots(mSnapshots, w, 1f);
				mSnapshots [2].TransitionTo (1f);
			} else if (mIntensity < 0.60) {
				//float[] w = { 1.0f, 1.0f, 1.0f, 1.0f, mIntensity / 0.6f, 0.0f, 0.0f };
				//mAudioMixer.TransitionToSnapshots(mSnapshots, w, 1f);
				mSnapshots [3].TransitionTo (1f);
			} else if (mIntensity < 0.70) {
				//float[] w = { 1.0f, 1.0f, 1.0f, 1.0f, 1.0f, mIntensity / 0.7f, 0.0f };
				//mAudioMixer.TransitionToSnapshots(mSnapshots, w, 1f);
				mSnapshots [4].TransitionTo (1f);
			} else if (mIntensity < 0.85) {
				//float[] w = { 1.0f, 1.0f, 1.0f, 1.0f, 1.0f, 1.0f, mIntensity / 0.85f };
				//mAudioMixer.TransitionToSnapshots(mSnapshots, w, 1f);
				mSnapshots [5].TransitionTo (1f);
			} else if (mIntensity < 0.95) {
				//float[] w = { 1.0f, 1.0f, mIntensity / 0.35f, 0.0f, 0.0f, 0.0f, 0.0f };
				//mAudioMixer.TransitionToSnapshots(mSnapshots, w, 1f);
				mSnapshots [6].TransitionTo (1f);
			} else {
				mSnapshots [7].TransitionTo (1f);
			}

			yield return new WaitForSeconds (interval);
		}
	}
}
