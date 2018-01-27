using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour {

    public float spawnWidth;
    private float timer;
    public float spawnRatio;
    private float rotFloat;
    private float randSize;
    private float randScale;

    public GameObject obstacle;
    private Transform tf;
    private Rigidbody rb;
    private Vector3 randomRot;

    void Start() {

    }

    void Update() {
        timer += Time.deltaTime;
        if (timer >= spawnRatio) {
            spawner();
            timer = 0;
        }

    }

    void spawner() {
        rotFloat = Random.Range(-100f, 100f);
        randSize = Random.Range(10, 60);
        randScale = Random.Range(90, 100);

        randomRot = new Vector3(rotFloat, rotFloat, rotFloat);
        obstacle = Instantiate(obstacle, new Vector3
            (Random.Range(transform.position.x, spawnWidth), transform.position.y, 0), Quaternion.Euler(200, 1, 1));

        rb = obstacle.GetComponent<Rigidbody>();
        rb.AddTorque(randomRot);
        rb.AddForce(Random.Range(-10, 10), (randSize * -2), 0);
        obstacle.transform.localScale = new Vector3(randScale, randScale, randScale);
    }
}
