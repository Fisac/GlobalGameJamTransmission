using UnityEngine;
using UnityEngine.UI;

public class PlayerEnergyController : MonoBehaviour
{
    private float energy;
    private float maxEnergy = 100;

    public Transform player1, player2;

    public GameObject yellowDeath, blueDeath;

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
            if (energy > maxEnergy)
            {
                energy = maxEnergy;
            }
            else if (energy < 0f)
            {
                Destroy(player1.gameObject);
                Destroy(player2.gameObject);
                Invoke("GameOver", 3);
                Instantiate(yellowDeath, player1.position, Quaternion.identity);
                Instantiate(blueDeath, player2.position, Quaternion.identity);
            }

            UpdateBar();
        }
    }

    void GameOver()
    {
        GetComponent<GameManager>().SetState(GameManager.State.GameOver);
    }

    private void Start()
    {
        Energy = maxEnergy;
    }

    public void StartEnergyDecline()
    {
        InvokeRepeating("EnergyDecline", 1f, .1f);
    }

    private void EnergyDecline()
    {
        Energy -= (Vector2.Distance(player1.position, player2.position) / 50f) + 0.01f;
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
