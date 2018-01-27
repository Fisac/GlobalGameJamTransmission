using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {

    [SerializeField] private GameObject particles;

    private bool dir;
    private float randPulse;

    private void Start() {
        randPulse = Random.Range(0.05f, 0.01f);
    }

    void Update () {

	    if(transform.position.y <= -30 || transform.position.y >= 35 || transform.position.x <= -25 || transform.position.x >= 25) {
            Destroy(this.gameObject);
        }

        PickDir();
	}

    void PickDir() {
        if (dir) {
            transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(100, 100, 100), randPulse);
            if (transform.localScale.x >= 95) {
                dir = false;
            }
        }

        if (!dir) {
            transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(75, 75, 75), randPulse);
            if (transform.localScale.x <= 80) {
                dir = true;
            }
        }
    }

    private void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.tag == "Obstacle") {
            Instantiate(particles, new Vector3(
                collision.contacts[0].point.x, collision.contacts[0].point.y, collision.contacts[0].point.z), Quaternion.Euler(0,0,0));
        }

        if (collision.gameObject.tag == "Player") {
            GameObject.Find("GameManager").GetComponent<PlayerEnergyController>().Energy -= 10;
            Instantiate(particles, transform.position, Quaternion.identity);
            Camera.main.GetComponent<CameraController>().Shake(1f, 0.1f);
            
            Destroy(this.gameObject);
        }
    }
}
