using UnityEngine;

public class EnergyLootPlayer1 : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Player 1")
        {
            collision.gameObject.GetComponent<PlayerEnergyInventory>().EnergyAmount += 25;
            Destroy(gameObject);
        }

        else if (collision.gameObject.name == "Player 2")
        {
            GameObject.Find("GameManager").GetComponent<PlayerEnergyController>().Energy -= 25;
            Destroy(gameObject);
        }
    }
}
