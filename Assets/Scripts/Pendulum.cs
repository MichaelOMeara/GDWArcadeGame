using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pendulum : MonoBehaviour
{
    public float torque = 5f;  // Adjust the torque force to control the swing

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Apply an initial torque to start the swinging motion
        rb.AddTorque(torque, ForceMode2D.Impulse);
    }

    void FixedUpdate()
    {
        // Apply a periodic force to keep the pendulum swinging
        rb.AddTorque(Mathf.Sin(Time.time) * torque * Time.fixedDeltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collided object has the tag "Player" or "playerTwo"
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("PlayerTwo"))
        {
            FindObjectOfType<FinishLine>().OnPlayerDestroyed(collision.gameObject.tag);

            // Destroy the player GameObject on contact with the pendulum
            Destroy(collision.gameObject);
        }
    }
}
