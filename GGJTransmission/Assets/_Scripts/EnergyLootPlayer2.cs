using UnityEngine;

public class EnergyLootPlayer2 : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player 2")
        {
            other.GetComponent<PlayerEnergyInventory>().EnergyAmount += 25;
            if (other.GetComponent<PlayerEnergyInventory>().AddEnergyObject() != null)
            {
                GetComponent<Rigidbody>().isKinematic = true;
                GetComponent<Despawner>().enabled = false;
                GetComponent<BoxCollider>().enabled = false;
                transform.SetParent(other.GetComponent<PlayerEnergyInventory>().AddEnergyObject());
                transform.GetChild(1).localScale = new Vector3(.2f, .2f, .2f);
                transform.localPosition = Vector3.zero;
            }
        }

        else if (other.name == "Player 1")
        {
            GameObject.Find("GameManager").GetComponent<PlayerEnergyController>().Energy -= 25;
            Destroy(gameObject);
        }
    }
}
