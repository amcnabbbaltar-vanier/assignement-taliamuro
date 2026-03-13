using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    void TogglePause()
    {
        bool isPaused = pauseUI.activeSelf;
        pauseUI.SetActive(!isPaused);
        Time.timeScale = isPaused? 1 : 0;
    }

    public void RestartLevel()
    {
        Time.timeScale = 1;
        GameManager.Instance.RestartLevel();
    }

    public void QuitToMenu()
    {
        Time.timeScale = 1;
        GameManager.Instance.LoadMainMenu();
    }
}
