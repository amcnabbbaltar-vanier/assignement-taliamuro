using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndScreen : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timeText;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Score: " + GameManager.Instance.score;
        timeText.text = "Time: " + GameManager.Instance.timer.ToString("F1");
    }

    public void RestartGame()
    {
        GameManager.Instance.ResetGame();
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }
}
