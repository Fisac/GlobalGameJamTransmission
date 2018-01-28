using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionSound : MonoBehaviour {

	void Start () {
        GameObject.Find("SoundManager").GetComponent<SoundManager>().playAsteroidHit();
	}
}
