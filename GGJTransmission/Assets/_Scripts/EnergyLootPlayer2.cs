using UnityEngine;

public class EnergyLootPlayer2 : MonoBehaviour {

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player 2")
        {
            collision.gameObject.GetComponent<PlayerEnergyInventory>().EnergyAmount += 50;
            Destroy(gameObject);
        }

        else if (collision.gameObject.name == "Player 1")
        {
            GameObject.Find("GameManager").GetComponent<PlayerEnergyController>().Energy -= 50;
            Destroy(gameObject);
        }
    }
}
