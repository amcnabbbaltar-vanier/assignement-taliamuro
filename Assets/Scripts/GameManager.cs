using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
    This class manages score, timer, and health
*/

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int score = 0;
    public int characterHealth = 3;
    public float timer = 0f;

    void Awake()
    {
        // If an instance does not exist
        if (Instance == null)
        {
            // Create the instance
            Instance = this;

            // This prevents the destruction of the game object when a new scene loads
            DontDestroyOnLoad(gameObject);
        }
        // If an instance does exist
        else
        {
            // Destroy the duplicate
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
    }

    /*
        Adds points to the player's score
    */
    public void AddScore(int amount)
    {
        score += amount;
    }

    /*
        Resets the whole game state
    */ 
    public void ResetGame()
    {
        score = 0;
        characterHealth = 3;
        timer = 0f;
    }

    /*
        Reloads the current level
    */
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    /*
        Loads the next level
    */
    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    /*
        Returns to the main menu
    */
    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
