using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    private float shake = 0;
    private float shakeAmount = .05f;
    private float decreaseFactor = 5f;

    private void Update() {
        if (shake > 0) {
            transform.localPosition = transform.position + Random.insideUnitSphere * shakeAmount;
            shake -= Time.deltaTime * decreaseFactor;
        }

        if(shake <= 0) {
            transform.position = new Vector3(0, 0, -10);
        }
    }

    public void Shake(float time) {
        shake = time;
    }

    public void Shake(float time, float amount) {
        shake = time;
        shakeAmount = amount;
    }
}
