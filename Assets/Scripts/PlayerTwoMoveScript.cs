using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTwoMoveScript : MonoBehaviour
{
    public float moveSpeed = 5f;     // Speed for left and right movement
    public float jumpForce = 10f;    // Force applied when jumping
    private Rigidbody2D rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Horizontal movement with left and right arrow keys
        float moveInput = 0f;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            moveInput = -1f;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            moveInput = 1f;
        }
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);

        // Jumping with alphanumeric 4 key
        if (Input.GetKeyDown(KeyCode.Alpha4) && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the player is on the ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        // Check if the player has left the ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
