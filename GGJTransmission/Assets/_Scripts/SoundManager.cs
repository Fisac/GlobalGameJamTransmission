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
        mAudioSources[0].pitch = Random.Range(.48f, .52f);
        mAudioSources[0].volume = Random.Range(.7f, .8f);
        mAudioSources [0].Play ();
		Debug.Log ("Energy pickup");
		mAudioSources [0].Play ();
	}

	public void playEnergyTransfer () {
		mAudioSources [2].Play ();
	}

    public void playDie()
    {
        mAudioSources[3].Play();
        StartCoroutine("PitchDownOverTime");
    }

    IEnumerator PitchDownOverTime()
    {
        while (mAudioSources[3].pitch > 0.0f)
        {
            yield return new WaitForSeconds(.1f);
            mAudioSources[3].pitch -= 0.01f;
        }        
    }

}
