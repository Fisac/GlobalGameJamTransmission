using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {

    [SerializeField] private GameObject particles;

    private void Start() {
    }

    void Update () {
	    if(transform.position.y <= -15 || transform.position.y >= 15 || transform.position.x <= -25 || transform.position.x >= 25) {
            Destroy(this.gameObject);
        }
	}

    private void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.tag == "Obstacle") {
            Instantiate(particles, new Vector3(
                collision.contacts[0].point.x, collision.contacts[0].point.y, collision.contacts[0].point.z), Quaternion.Euler(0,0,0));
        }

        if (collision.gameObject.tag == "Player") {
            GameObject.Find("GameManager").GetComponent<PlayerEnergyController>().Energy -= 10;
            Destroy(this.gameObject);
        }
    }
}
