using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class PlayerEnergyInventory : MonoBehaviour
{

    private int energyAmount;

    private List<GameObject> energyParticles = new List<GameObject>();

    public GameObject energyParticle, mergeEffect;
    private GameObject player2;

    public int EnergyAmount
    {
        get
        {
            return energyAmount;
        }
        set
        {
            if (value == 0)
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

    private void Start()
    {
        player2 = GameObject.Find("Player 2");
    }

    void energyIncreased()
    {
        GameObject particle = Instantiate(energyParticle, transform.position, Quaternion.identity, transform);
        energyParticles.Add(particle);
    }

    void energyDump()
    {
        foreach (GameObject g in energyParticles)
        {
            Destroy(g);
        }

        StartCoroutine("EnergyTransfer");
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

    bool go = true;

    IEnumerator EnergyTransfer()
    {
        StartCoroutine("Timer");

        if (gameObject.name == "Player 1")
        {
            GameObject merge = Instantiate(mergeEffect, ((transform.position + player2.transform.position) / 2), Quaternion.identity);
        }

        while (go == true)
        {
            Vector3 prevPos = transform.position;
            yield return new WaitForEndOfFrame();
            transform.position = prevPos;
        }
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(3f);
        go = false;
    }
}
