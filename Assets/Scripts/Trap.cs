using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    /*
        Damages the character when they touch a trap
    */
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            CharacterHealth health = collision.gameObject.GetComponent<CharacterHealth>();

            if (health != null)
            {
                health.TakeDamage(1);
            }
        }
    }
}
