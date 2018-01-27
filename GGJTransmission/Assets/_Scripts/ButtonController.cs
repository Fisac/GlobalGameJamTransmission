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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Joystick1Button7))
        {
            if (gm.GetState() == "MainMenu")
                gm.SetState(GameManager.State.Play);
        }
    }
}
