using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimatorController : MonoBehaviour
{
    private Animator animator;
    private Rigidbody rb;
    private CharacterMovement movement;
    void Start()
    {
        animator = GetComponent<Animator>();

        // Debug.Log("Animator name: " + animator.gameObject.name);

        // if (animator == null)
        // {
        //     Debug.LogError("Animator not found");
        // }
        // else if (animator.runtimeAnimatorController == null)
        // {
        //     Debug.LogError("Animator controller missing");
        // }

        rb = GetComponent<Rigidbody>();
        movement = GetComponent<CharacterMovement>();
    }

    void Update()
    {
        animator.SetFloat("CharacterSpeed", rb.velocity.magnitude);
        animator.SetBool("IsGrounded", movement.isGrounded);

        if (Input.GetButtonUp("Fire1"))
        {
            animator.SetTrigger("DoFlip");
        }

        // animator.SetFloat("VerticalSpeed", rb.velocity.y);
    }

    // public void TriggerDoubleJump()
    // {
    //     animator.SetTrigger("DoubleJump");
    // }
}
