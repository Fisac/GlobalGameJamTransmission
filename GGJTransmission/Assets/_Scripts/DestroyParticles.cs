using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyParticles : MonoBehaviour {

    private float time;

	void Start () {
        time = 0;
	}
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;

        if (time >= 2)
            Destroy(this.gameObject);
	}
}
