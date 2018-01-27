using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour {

    public float spawnWidth;
    public float spawnRatio;
    public float minSpeed;
    public float maxSpeed;
    private float timer;
    private float rotFloat;
    private float randSpeed;
    private float randScale;

    [SerializeField] private GameObject obstacle;
    private GameObject spawned;

    private Transform tf;
    private Rigidbody rb;
    private Vector3 randomRot;

    void Update() {
        timer += Time.deltaTime;
        spawnRatio -= Time.deltaTime/250;

        if (timer >= spawnRatio) {
            spawner();
            timer = 0;
        }

    }

    void spawner() {

        rotFloat = Random.Range(-100f, 100f);
        randSpeed = Random.Range(minSpeed, maxSpeed) * -1;
        randScale = Random.Range(90, 100);

        randomRot = new Vector3(rotFloat, rotFloat, rotFloat);

        if(obstacle != null)
            spawned = Instantiate(obstacle, new Vector3(
                Random.Range(transform.position.x, spawnWidth), transform.position.y, 0), Quaternion.Euler(200, 1, 1));

        if(obstacle != null) {
            rb = spawned.GetComponent<Rigidbody>();
            rb.AddTorque(randomRot);
            rb.AddForce(Random.Range(-400, 400), randSpeed, 0);
            spawned.transform.localScale = new Vector3(randScale, randScale, randScale);
        }
    }
}
