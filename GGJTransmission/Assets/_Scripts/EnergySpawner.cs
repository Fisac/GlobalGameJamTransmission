using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergySpawner : MonoBehaviour {

    public float spawnWidth;
    public float spawnRatio;
    public float minSpeed;
    public float maxSpeed;

    private float randSpeed;
    private float timer;

    private GameObject[] energies;
    public GameObject blueEnergy;
    public GameObject yellowEnergy;
    private GameObject obstacle;
    private Rigidbody rb;

    private void Start() {
        energies = new GameObject[2];

        energies[0] = blueEnergy;
        energies[1] = yellowEnergy;
    }

    void Update() {
        timer += Time.deltaTime;
        if (timer >= spawnRatio) {
            spawner();
            timer = 0;
        }
    }

    void spawner() {
        obstacle = energies[Random.Range(0, energies.Length)];
        randSpeed = Random.Range(minSpeed, maxSpeed) * -1;

        if (obstacle != null) {
            obstacle = Instantiate(obstacle, new Vector3
            (Random.Range(transform.position.x, spawnWidth), transform.position.y, 0), Quaternion.Euler(0, 0, 0));

            rb = obstacle.GetComponent<Rigidbody>();

            rb.AddForce(0, randSpeed, 0);
        }
    }
}
