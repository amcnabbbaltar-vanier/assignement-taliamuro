using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float walkSpeed = 5f;
    public float runMultiplier = 2f;
    public float jumpForce = 12f;
    private Rigidbody rb;
    public bool isGrounded;
    private float jumpHoldTimer;
    private bool isHoldingJump;
    public bool canDoubleJump = false;
    private bool hasUsedDoubleJump = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
        HandleJumpInput();
    }

    /*
        Handles forizontal player movement
    */
    void HandleMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        float speed = walkSpeed;

        // Holding shift makes the player run
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed *= runMultiplier;
        }

        Vector3 velocity = rb.velocity;
        velocity.x = horizontalInput * speed;
        rb.velocity = velocity;
    }

    /*
        Handles jump input including holding time
    */
    void HandleJumpInput()
    {
        // When the spacebar is first pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isHoldingJump = true;
            jumpHoldTimer = 0;
        }

        // While the key is being held
        if (isHoldingJump)
        {
            jumpHoldTimer += Time.deltaTime;

            // Jump after holding for 3 seconds
            if (jumpHoldTimer >= 3f)
            {
                PerformJump();
                isHoldingJump = false;
            }
        }

        // If the key is released early
        if (Input.GetKeyUp(KeyCode.Space))
        {
            if (isHoldingJump)
            {
                PerformJump();
                isHoldingJump = false;
            }
        }
    }

    /*
        Executes the jump or double jump
    */
    void PerformJump()
    {
        if (isGrounded)
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, 0);
            hasUsedDoubleJump = false;
        }
        else if (canDoubleJump && !hasUsedDoubleJump)
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, 0);
            hasUsedDoubleJump = true;
        }
    }

    /*
        Detects if the player is touching the ground
    */
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }


}
