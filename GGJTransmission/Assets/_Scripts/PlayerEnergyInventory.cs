using System.Collections.Generic;
using UnityEngine;

public class PlayerEnergyInventory : MonoBehaviour {

    private int energyAmount;

    private List<GameObject> energyParticles = new List<GameObject>();

    public GameObject energyParticle;

    public int EnergyAmount
    {
        get
        {
            return energyAmount;
        }
        set
        {
            if(value == 0)
            {
                energyDump();
            }
            if (value > energyAmount)
            {
                energyIncreased();
            }
            energyAmount = value;
        }
    }

    void energyIncreased()
    {
        GameObject particle = Instantiate(energyParticle, transform.position, Quaternion.identity, transform);
        energyParticles.Add(particle);
    }

    void energyDump()
    {
        foreach(GameObject g in energyParticles)
        {
            Destroy(g);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            int energyGain = collision.gameObject.GetComponent<PlayerEnergyInventory>().EnergyAmount + EnergyAmount;
            collision.gameObject.GetComponent<PlayerEnergyInventory>().EnergyAmount = 0;
            energyAmount = 0;
            GameObject.Find("GameManager").GetComponent<PlayerEnergyController>().Energy += energyGain;
        }
    }
}
