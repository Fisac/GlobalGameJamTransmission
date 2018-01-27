using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour {

    public GameObject player1, player2;

    public void SpawnPlayers()
    {
        GameObject p1 = Instantiate(player1, new Vector3(5, 0, 0), Quaternion.identity);
        GameObject p2 = Instantiate(player2, new Vector3(-5, 0, 0), Quaternion.identity);
        GameObject.Find("GameManager").GetComponent<PlayerEnergyController>().player1 = p1.transform;
        GameObject.Find("GameManager").GetComponent<PlayerEnergyController>().player2 = p2.transform;
        GameObject.Find("Main Camera").GetComponent<CameraController> ().player1 = p1.transform;
        GameObject.Find("Main Camera").GetComponent<CameraController>().player2 = p2.transform;
        p1.GetComponent<PlayerEnergyInventory>().player1 = p1;
        p1.GetComponent<PlayerEnergyInventory>().player2 = p2;
        p2.GetComponent<PlayerEnergyInventory>().player1 = p1;
        p2.GetComponent<PlayerEnergyInventory>().player2 = p2;
        p1.name = "Player 1";
        p2.name = "Player 2";
    }
}
