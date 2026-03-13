using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    /*
        Damages the character when they touch a trap
    */
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CharacterHealth health = other.GetComponent<CharacterHealth>();

            if (health != null)
            {
                health.TakeDamage(1);
            }
        }
    }
}
