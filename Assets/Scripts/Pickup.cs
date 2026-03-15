using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    Pickups: speed, jump, score
*/

public class Pickup : MonoBehaviour
{
    public enum PickupType
    {
        SpeedBoost,
        JumpBoost,
        ScoreBoost
    }

    public PickupType type;

    public float rotationSpeed = 60f;

    // Update is called once per frame
    void Update()
    {
        // Rotate pickup
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        
        if (type == PickupType.ScoreBoost)
        {
            GameManager.Instance.AddScore();
            Destroy(gameObject);
        }

        if (type == PickupType.SpeedBoost)
        {
            StartCoroutine(SpeedBoost(other));
        }

        if (type == PickupType.JumpBoost)
        {
            StartCoroutine(JumpBoost(other));
        }
    }

    IEnumerator SpeedBoost(Collider character)
    {
        CharacterMovement movement = character.GetComponent<CharacterMovement>();
        movement.walkSpeed *= 2;
        yield return new WaitForSeconds(5);
        movement.walkSpeed /= 2;
        DisablePickup();
        yield return new WaitForSeconds(30);
        EnablePickup();
    }

    IEnumerator JumpBoost(Collider character)
    {
        CharacterMovement movement = character.GetComponent<CharacterMovement>();
        movement.jumpForce = 8;
        DisablePickup();
        yield return new WaitForSeconds(30);
        movement.jumpForce = 5;
        EnablePickup();
    }

    void DisablePickup()
    {
        GetComponent<Renderer>().enabled = false;
        GetComponent<Collider>().enabled = false;
    }

    void EnablePickup()
    {
        GetComponent<Renderer>().enabled = true;
        GetComponent<Collider>().enabled = true;
    }
}
