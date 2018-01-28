using UnityEngine;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour {

	public enum State { MainMenu, Play, GameOver }
    private State state;

    public Transform mainMenuUI, gameOverUI, uiBackground;
    public GameObject[] firstSelectedButton;
    private EventSystem eventSystem;
    public PlayerSpawner playerSpawner;
    public ObstacleSpawner obstacleSpawner;

    public void SetState(State newState)
    {
        if (newState == State.MainMenu)
            OnMainMenu();
        else if (newState == State.Play)
            OnPlay();
        else if (newState == State.GameOver)
            OnGameOver();

        state = newState;
    }

    private void Start()
    {
        eventSystem = GameObject.Find("EventSystem").GetComponent<EventSystem>();
        playerSpawner = GetComponent<PlayerSpawner>();
        obstacleSpawner = GameObject.Find("ObstacleSpawner").GetComponent<ObstacleSpawner>();
        obstacleSpawner.gameObject.SetActive(false);
        SetState(State.MainMenu);
    }

    private void OnMainMenu()
    {
        uiBackground.gameObject.SetActive(true);
        mainMenuUI.gameObject.SetActive(true);
        gameOverUI.gameObject.SetActive(false);
        eventSystem.SetSelectedGameObject(firstSelectedButton[0]);
    }

    private void OnPlay()
    {
        if (state == State.Play)
            return;

        playerSpawner.SpawnPlayers();
        obstacleSpawner.gameObject.SetActive(true);
        GetComponent<PlayerEnergyController>().StartEnergyDecline();
        uiBackground.gameObject.SetActive(false);
        mainMenuUI.gameObject.SetActive(false);
        gameOverUI.gameObject.SetActive(false);
    }

    private void OnGameOver()
    {
        uiBackground.gameObject.SetActive(true);
        mainMenuUI.gameObject.SetActive(false);
        gameOverUI.gameObject.SetActive(true);
        eventSystem.SetSelectedGameObject(firstSelectedButton[1]);
    }

    public string GetState()
    {
        return state.ToString();
    }
}
