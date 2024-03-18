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

    private int winner;

    public int Winner { get; private set; } = -1;

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
        winner = -1;
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
                JoinPlayers();
                break;
            case GameState.End:
                Debug.Log("Loading Game Over Scene");
                controller.LoadEndScene();
                Debug.Log($"Player {winner} wins");
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
    /// <param name="playerNumber"> The ID of player </param>
    public void UpdateHealth(int playerNumber, float currentHealth, float maxHealth)
    {
        // Invoke the event to notify subscribers of the health change
        OnHealthChange?.Invoke(playerNumber, currentHealth, maxHealth);

        // If the current health passed in is <= 0, then determine the winner based on the player number and update the game state
        if (currentHealth <= 0)
        {
            winner = playerNumber == 1 ? 2 : 1;
            UpdateState(GameState.End);
        }
    }

    /// <summary>
    /// Initiate the players with the player input manager
    /// </summary>
    public void JoinPlayers()
    {
        player1 = GameObject.Find("Player1");
        player2 = GameObject.Find("Player2");

        PlayerInputManager.instance.JoinPlayer(0);
        PlayerInputManager.instance.JoinPlayer(1);
    }
}