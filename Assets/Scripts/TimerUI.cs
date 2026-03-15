using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerUI : MonoBehaviour
{
    public Text timerText;
    void Update()
    {
        timerText.text = "Time: " + GameManager.Instance.timer.ToString("F1");
    }
}
