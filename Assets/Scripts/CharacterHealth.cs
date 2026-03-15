using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHealth : MonoBehaviour
{
    public float damageCooldown = 1f; // 1 second cooldown
    private bool canTakeDamage = true;
    /*
        Called when the character takes damage
    */
    public void TakeDamage(int amount, bool forceRestart = false)
    {
        if (!canTakeDamage)
        {
            return;
        }

        GameManager.Instance.characterHealth -= amount;

        // Prevent health from going below zero
        if (GameManager.Instance.characterHealth < 0)
        {
            GameManager.Instance.characterHealth = 0;
        }

        Debug.Log("Health: " + GameManager.Instance.characterHealth);

        // determine whether the level should restart
        if (forceRestart)
        {
            // always restart when falling
            if (GameManager.Instance.characterHealth == 0)
            {
                // If health is 0, reset to 3
                GameManager.Instance.characterHealth = 3;
            }
            GameManager.Instance.RestartLevel();
        }
        else
        {
            // only restart if health is 0 (trap logic)
            if (GameManager.Instance.characterHealth == 0)
            {
                GameManager.Instance.characterHealth = 3;
                GameManager.Instance.RestartLevel();
            }
        }

        StartCoroutine(DamageCooldown());
    }

    IEnumerator DamageCooldown()
    {
        canTakeDamage = false;
        yield return new WaitForSeconds(damageCooldown);
        canTakeDamage = true;
    }
}
