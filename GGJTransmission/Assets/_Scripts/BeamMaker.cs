using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamMaker : MonoBehaviour {

    public GameObject particle;

    [HideInInspector]
    public Transform target;

	public void SendParticle()
    {
        GameObject beam = Instantiate(particle, transform.position, Quaternion.identity);
        beam.GetComponent<BeamParticle>().target = target;
        
    }
}
