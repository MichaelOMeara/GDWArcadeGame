using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeMovement : MonoBehaviour
{
    public float speed = 2f;      // Movement speed of the spikes
    public float distance = 2f;   // The distance the spikes move up and down

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;  // Record the starting position
    }

    void Update()
    {
        // Calculate new Y position using a sine wave
        float newY = startPos.y + Mathf.Sin(Time.time * speed) * distance;
        transform.position = new Vector3(startPos.x, newY, startPos.z);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collided object has the tag "Player" or "playerTwo"
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("PlayerTwo"))
        {
            FindObjectOfType<FinishLine>().OnPlayerDestroyed(collision.gameObject.tag);

            // Destroy the player GameObject on contact with spikes
            Destroy(collision.gameObject);
        }
    }
}
