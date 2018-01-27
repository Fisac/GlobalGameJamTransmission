using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {
	
	void Update () {
	    if(transform.position.y <= -15 || transform.position.y >= 15 || transform.position.x <= -25 || transform.position.x >= 25) {
            Destroy(this.gameObject);
        }
	}

    private void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.tag == "Obstacle") {
            
        }
    }
}
