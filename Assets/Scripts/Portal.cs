using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public bool isFinalPortal = false;
    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Portal")) return;

        if (isFinalPortal)
        {
            Debug.Log("Entered portal");
            GameManager.Instance.gameFinished = true;
        }

            GameManager.Instance.LoadNextLevel();
    }
}
