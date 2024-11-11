using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FinishLine : MonoBehaviour
{
    public TextMeshProUGUI resultText;
    public Button resetButton;

    private bool raceFinished = false;
    private bool player1Destroyed = false;
    private bool player2Destroyed = false;

    void Start()
    {
        // Ensure the UI elements are inactive initially
        resultText.gameObject.SetActive(false);
        resetButton.gameObject.SetActive(false);

        // Add the listener for the reset button
        resetButton.onClick.AddListener(ResetScene);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the race is finished to prevent multiple triggers
        if (!raceFinished && (collision.CompareTag("Player") || collision.CompareTag("PlayerTwo")))
        {
            raceFinished = true;

            // Display which player won
            if (collision.CompareTag("Player"))
            {
                resultText.text = "Player 1 Wins!";
            }
            else if (collision.CompareTag("PlayerTwo"))
            {
                resultText.text = "Player 2 Wins!";
            }

            // Show the winner message and reset button
            resultText.gameObject.SetActive(true);
            resetButton.gameObject.SetActive(true);
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
            resultText.text = "Both players lose!";
            resultText.gameObject.SetActive(true);
            resetButton.gameObject.SetActive(true);
        }
    }

    void ResetScene()
    {
        // Reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}