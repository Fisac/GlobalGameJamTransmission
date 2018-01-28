using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamParticle : MonoBehaviour {

    public Transform target;
    public int speed;

	void Update () {
        if (target == null)
            return;

        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        if(Vector3.Distance(transform.position, target.position) < 1)
        {
            Destroy(gameObject);
        }
	}
}
