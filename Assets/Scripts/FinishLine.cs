using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    public TextMeshProUGUI resultText;

    private bool raceFinished = false;
    private bool player1Finished = false;
    private bool player2Finished = false;
    private bool player1Destroyed = false;
    private bool player2Destroyed = false;

    void Start()
    {
        // Ensure the UI element is inactive initially
        resultText.gameObject.SetActive(false);
    }

    void Update()
    {
        // Reset the scene using the Enter key
        if (raceFinished && Input.GetKeyDown(KeyCode.Return))
        {
            ResetScene();
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!raceFinished)
        {
            // Check if Player 1 reaches the finish line
            if (collision.CompareTag("Player"))
            {
                player1Finished = true;
            }

            // Check if Player 2 reaches the finish line
            if (collision.CompareTag("PlayerTwo"))
            {
                player2Finished = true;
            }

            // Determine the result
            if (player1Finished && player2Finished)
            {
                raceFinished = true;
                resultText.text = "Both players win! Hit enter to restart.";
            }
            else if (player1Finished)
            {
                raceFinished = true;
                resultText.text = "Player 1 Wins! Hit enter to restart.";
            }
            else if (player2Finished)
            {
                raceFinished = true;
                resultText.text = "Player 2 Wins! Hit enter to restart.";
            }

            // Show the result message
            if (raceFinished)
            {
                resultText.gameObject.SetActive(true);
            }
        }
    }

    // This method can be called from other scripts when a player is destroyed
    public void OnPlayerDestroyed(string playerTag)
    {
        if (playerTag == "Player")
        {
            player1Destroyed = true;
        }
        else if (playerTag == "PlayerTwo")
        {
            player2Destroyed = true;
        }

        // Check if both players have been destroyed
        if (player1Destroyed && player2Destroyed && !raceFinished)
        {
            raceFinished = true;
            resultText.text = "Both players lose! Hit enter to restart.";
            resultText.gameObject.SetActive(true);
        }
    }

    void ResetScene()
    {
        // Reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
