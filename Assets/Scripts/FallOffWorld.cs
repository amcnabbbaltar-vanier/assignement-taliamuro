using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallOffWorld : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            CharacterHealth health = collision.gameObject.GetComponent<CharacterHealth>();

            if (health != null)
            {
                health.TakeDamage(1);
                GameManager.Instance.RestartLevel();
            }
        }
    }
}
