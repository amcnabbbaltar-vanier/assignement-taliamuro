using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelEndUI : MonoBehaviour
{
    public Text scoreText;
    public Text timeText;
    // void Update()
    // {
    //     timeText.text = "Time: " + GameManager.Instance.timer.ToString() + " seconds";
    // }

    void Start()
    {
        float time = GameManager.Instance.timer;

        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);

        scoreText.text = "Score: " + GameManager.Instance.score;
        timeText.text = "Time: " + minutes.ToString("00") + ":" + seconds.ToString("00");
    }
}
