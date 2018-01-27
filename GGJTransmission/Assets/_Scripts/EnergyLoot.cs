using UnityEngine;

public class EnergyLoot : MonoBehaviour {

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerEnergyInventory>().EnergyAmount += 50;
            Destroy(gameObject);
        }
    }
}
