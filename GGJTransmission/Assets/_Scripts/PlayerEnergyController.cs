using UnityEngine;
using UnityEngine.UI;

public class PlayerEnergyController : MonoBehaviour
{
    private float energy;
    private float maxEnergy = 100;

    public Transform player1, player2;

    public Image Fg;
    public Light energyDirectionalLight;
    private Color energyColor;
    private float red = 0f;
    private float green = 200f;
    private float energyPercent;

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
        energyPercent = energy / maxEnergy;
        Fg.fillAmount = energyPercent;
        red = (255 - (255 * energyPercent)) / 255f;
        green = (255 * (energyPercent)) / 255f;
        if (green < 0f)
            green = 0f;
        if (red > 1f)
            red = 1f;
        energyColor = new Color(red, green, 0f);
        energyDirectionalLight.color = energyColor;
    }
}
