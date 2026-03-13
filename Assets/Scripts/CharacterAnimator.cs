using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimator : MonoBehaviour
{
    private Animator animator;
    private Rigidbody rb;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float speed = Mathf.Abs(rb.velocity.x);

        animator.SetFloat("Speed", speed);
        animator.SetFloat("VerticalSpeed", rb.velocity.y);
    }

    public void TriggerDoubleJump()
    {
        animator.SetTrigger("DoubleJump");
    }
}
