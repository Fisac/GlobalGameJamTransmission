using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour {

    private GameManager gm;

    private void Start()
    {
        gm = GetComponent<GameManager>();
    }

    public void StartGame()
    {
        gm.SetState(GameManager.State.Play);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
