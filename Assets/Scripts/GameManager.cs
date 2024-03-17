using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Properties;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    private SceneController controller;

    private GameObject player1;
    private GameObject player2;

    public static GameManager instance { get; private set; }

    public GameState currentState { get; private set; }

    // To notify subscribers of the state change
    public static event Action<GameState> OnStateChange;

    // To notify subscribers of the health change
    public static event Action<int, float, float> OnHealthChange;

    void Awake()
    {
        if (GameManager.instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            // On awake, the initial game state is set to the menu
            this.currentState = GameState.Menu;
            Debug.Log("Initial Game State: " + GameState.Menu);
        }
        else
        {
            // If there is already a game manager, destroy the new one
            Destroy(gameObject);
        }

        controller = gameObject.AddComponent<SceneController>();
    }

    /// <summary>
    /// Update the current state of the game
    /// </summary>
    /// <param name="newState"> The new state that the game should change to </param>
    public void UpdateState(GameState newState)
    {
        // If the new state is the same as the current state, do nothing
        if (this.currentState == newState)
        {
            return;
        }

        // Update the current state
        currentState = newState;

        switch (newState)
        {
            case GameState.Menu:
                Debug.Log("Loading Menu Scene");
                controller.LoadStartScene();
                break;
            case GameState.Play:
                Debug.Log("Loading Main Scene");
                controller.LoadMainScene();

                // Find the player objects and join them to the game
                player1 = GameObject.Find("Player1");
                player2 = GameObject.Find("Player2");

                PlayerInputManager.instance.JoinPlayer(0);
                PlayerInputManager.instance.JoinPlayer(1);

                break;
            case GameState.GameOver:
                Debug.Log("Loading Game Over Scene");
                controller.LoadEndScene();
                break;
        }

        // Invoke the event to notify subscribers of the state change
        OnStateChange?.Invoke(newState);
    }

    /// <summary>
    /// Update the health of the player
    /// </summary>
    /// <param name="currentHealth"> The current health of the player </param>
    /// <param name="maxHealth"> The maximum health of the player </param>
    /// <param name="player"> The player object </param>
    public void UpdateHealth(int playerNumber, float currentHealth, float maxHealth)
    {
        // Invoke the event to notify subscribers of the health change
        OnHealthChange?.Invoke(playerNumber, currentHealth, maxHealth);

        // If the player's health is less than or equal to 0, update the game state to GameOver
        if (player1.GetComponent<PlayerHealth>().NoHealth())
        {
            UpdateState(GameState.GameOver);
        }
    }
}