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
    public void TakeDamage(int amount)
    {
        if (!canTakeDamage)
        {
            return;
        }

        GameManager.Instance.characterHealth -= amount;

        Debug.Log("Health: " + GameManager.Instance.characterHealth);

        // If the health reaches zero, restart the level
        if (GameManager.Instance.characterHealth <= 0)
        {
            GameManager.Instance.RestartLevel();
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
