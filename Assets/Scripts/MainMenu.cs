using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void ButtonClicked(string action)
    {
        // check the name of the clicked game object
        if (action == "Play")
        {
            SceneManager.LoadScene(1);
        }
        else if (action == "Quit")
        {
            Application.Quit();
        }
    }
}
