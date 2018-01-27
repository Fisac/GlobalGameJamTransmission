using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSpawner : MonoBehaviour {

    public float spawnWidth;
    private float timer;
    public float spawnRatio;
    private float rotFloat;
    private float randSize;

    public GameObject asteroid;
    private Transform tf;
    private Rigidbody rb;
    private Vector3 randomRot;
	
	void Start () {
        
    }

	void Update () {
        timer += Time.deltaTime;
        if(timer >= spawnRatio) {
            spawner();
            timer = 0;
        }

	}

    void spawner() {
        rotFloat = Random.Range(-100f, 100f);
        randSize = Random.Range(10, 60);

        randomRot = new Vector3(rotFloat, rotFloat, rotFloat);
        asteroid = Instantiate(asteroid, new Vector3
            (Random.Range(transform.position.x, spawnWidth), transform.position.y, transform.position.z - randSize/10), Quaternion.Euler(200, 1, 1));

        rb = asteroid.GetComponent<Rigidbody>();
        rb.AddTorque(randomRot);
        rb.AddForce(Random.Range(-50, 50), (randSize * -1), 0);
        asteroid.transform.localScale = new Vector3(randSize, randSize, randSize);
    }
}
