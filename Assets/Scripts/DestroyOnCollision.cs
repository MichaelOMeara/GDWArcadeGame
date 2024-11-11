using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnCollision : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collided object has the tag "Projectile", "Player", or "PlayerTwo"
        if (collision.gameObject.CompareTag("Projectile") ||
            collision.gameObject.CompareTag("Player") ||
            collision.gameObject.CompareTag("PlayerTwo"))
        {
            FindObjectOfType<FinishLine>().OnPlayerDestroyed(collision.gameObject.tag);
            // Destroy the collided object
            Destroy(collision.gameObject);
            // Destroy the current object this script is attached to
            Destroy(gameObject);
        }
    }
}
