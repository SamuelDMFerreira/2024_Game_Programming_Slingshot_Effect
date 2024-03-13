using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Properties;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class GameManager : MonoBehaviour
{
    private SceneController controller;

    public static GameManager instance { get; private set; }

    public GameState currentState { get; private set; }

    // To notify subscribers of the state change
    public static event Action<GameState> OnStateChange; 

    // To notify subscribers of the health change
    // Health bar controller will subscribe to this event to update the health bar
    public static event Action<float, float> OnHealthChange;

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
            case GameState.Online:
                Debug.Log("Initialize online settings");
                instance.UpdateState(GameState.Play);
                break;
            case GameState.Local:
                Debug.Log("Initialize local settings");
                instance.UpdateState(GameState.Play);
                break;
            case GameState.Play:
                Debug.Log("Loading Main Scene");
                controller.LoadMainScene();
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
    public void UpdateHealth(float currentHealth, float maxHealth)
    {
        // Invoke the event to notify subscribers of the health change
        OnHealthChange?.Invoke(currentHealth, maxHealth);

        // If the player's health is less than or equal to 0, update the game state to GameOver
        if (currentHealth <= 0)
        {
            UpdateState(GameState.GameOver);
        }
    }
}