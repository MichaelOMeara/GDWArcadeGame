using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnCollision : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collided object has the tag "Projectile" (or "Player" as needed)
        if (collision.gameObject.CompareTag("Projectile") || collision.gameObject.CompareTag("Player"))
        {
            // Destroy the collided object
            Destroy(collision.gameObject);
            // Destroy the current object this script is attached to
            Destroy(gameObject);
        }
    }
}