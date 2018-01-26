using UnityEngine;
using UnityEngine.UI;

public class PlayerEnergyController : MonoBehaviour
{
    private float energy;
    private float maxEnergy = 100;

    public Transform player1, player2;

    public Image Fg;

    public float Energy
    {
        get
        {
            return energy;
        }
        set
        {
            energy = value;
            if(energy > maxEnergy)
            {
                energy = maxEnergy;
            }
            UpdateBar();
        }
    }

    private void Start()
    {
        InvokeRepeating("EnergyDecline", 1, 1);
        Energy = maxEnergy;
    }

    void EnergyDecline()
    {
        Energy -= (Vector2.Distance(player1.position, player2.position) / 5) + 1;
    }

    void UpdateBar()
    {
        Fg.fillAmount = energy / maxEnergy;
    }
}
