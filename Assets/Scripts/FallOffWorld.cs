using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallOffWorld : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CharacterHealth health = other.GetComponent<CharacterHealth>();

            if (health != null)
            {
                health.TakeDamage(1, true); // force the restart without resetting health
            }
        }
    }
}
