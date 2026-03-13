using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHealth : MonoBehaviour
{
    /*
        Called when the character takes damage
    */
    public void TakeDamage(int amount)
    {
        GameManager.Instance.characterHealth -= amount;

        // If the health reaches zero, restart the level
        if (GameManager.Instance.characterHealth <= 0)
        {
            GameManager.Instance.RestartLevel();
        }
    }
}
