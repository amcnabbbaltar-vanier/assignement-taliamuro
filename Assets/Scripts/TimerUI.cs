using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerUI : MonoBehaviour
{
    public TextMeshPro timerText;
    void Update()
    {
        timerText.text = "Time: " + GameManager.Instance.timer.ToString("F1");
    }
}
