using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class PlayerEnergyInventory : MonoBehaviour
{
    private int energyAmount;

    private Transform gm;

    private List<GameObject> energyParticles = new List<GameObject>();

    public GameObject energyParticle, mergeEffect;
    public GameObject player2, player1;
    public Transform[] energyHolder;

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
        //player2 = GameObject.Find("Player 2");
        //player1 = GameObject.Find("Player 1");
        gm = GameObject.Find("GameManager").transform;
    }

    public Transform AddEnergyObject()
    {
        foreach (Transform item in energyHolder)
        {
            if (item.childCount == 0)
                return item;
        }
        return null;

    }

    void energyIncreased()
    {
        //GameObject particle = Instantiate(energyParticle, transform.position, Quaternion.identity, transform);
        //energyParticles.Add(particle);
    }

    void energyDump()
    {
        foreach (GameObject g in energyParticles)
        {
            Destroy(g);
        }

        foreach (Transform item in energyHolder)
        {
            Destroy(item.GetChild(0).gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if(player1.GetComponent<PlayerEnergyInventory>().EnergyAmount > 50 && player2.GetComponent<PlayerEnergyInventory>().EnergyAmount > 50)
            {
                energyDump();
                StartCoroutine("EnergyTransfer");
                int energyGain = collision.gameObject.GetComponent<PlayerEnergyInventory>().EnergyAmount + EnergyAmount;
                collision.gameObject.GetComponent<PlayerEnergyInventory>().EnergyAmount = 0;
                energyAmount = 0;
                gm.GetComponent<PlayerEnergyController>().Energy += energyGain;
            }

        }
    }

    bool go = true;

    IEnumerator EnergyTransfer()
    {
        StartCoroutine("Timer");
        if (transform.name == "Player 2")
        {
            GameObject merge = Instantiate(mergeEffect, ((transform.position + player1.transform.position) / 2), Quaternion.identity);
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
