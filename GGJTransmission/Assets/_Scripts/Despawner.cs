using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Despawner : MonoBehaviour {
	
	void Update () {
        if (transform.position.y <= -30 || transform.position.y >= 35 || transform.position.x <= -25 || transform.position.x >= 25) {
            Destroy(this.gameObject);
        }
    }
}
