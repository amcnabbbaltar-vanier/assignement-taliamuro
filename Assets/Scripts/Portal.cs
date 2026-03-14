using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Portal"))
        {
            Debug.Log("Entered portal");
            GameManager.Instance.LoadNextLevel();
        }
    }

    // void OnTriggerEnter(Collider other)
    // {
    //     if (other.CompareTag("Portal"))
    //     {
    //         Debug.Log("Portal touched");

    //         if (GameManager.Instance != null)
    //         {
    //             GameManager.Instance.LoadNextLevel();
    //         }
    //         else
    //         {
    //             Debug.LogError("GameManager Instance is NULL");
    //         }
    //     }
    // }
}
