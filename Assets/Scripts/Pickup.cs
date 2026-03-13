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
        Score
    }

    public PickupType type;

    public float rotationSpeed = 60f;

    // Update is called once per frame
    void Update()
    {
        // Rotate pickup
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);

        // Hover animation
        float hover = Mathf.Sin(Time.time) * 0.002f;
        transform.position += new Vector3(0, hover, 0);
    }

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        
        if (type == PickupType.Score)
        {
            GameManager.Instance.AddScore(50);
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
        movement.canDoubleJump = true;
        DisablePickup();
        yield return new WaitForSeconds(30);
        movement.canDoubleJump = false;
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
