using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEnd : MonoBehaviour
{
    public bool isFinalLevel = false;

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Character")) return;

        if (isFinalLevel)
        {
            SceneManager.LoadScene("EndScene");
        }
        else
        {
            GameManager.Instance.LoadNextLevel();
        }
    }
}
