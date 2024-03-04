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
    // public static event Action<HealthBarController> OnHealthChange;

    void Awake()
    {
        if (GameManager.instance == null)
        {
            instance = this;
            // On awake, the initial game state is set to the menu
            this.currentState = GameState.Menu;
            Debug.Log("Initial Game State: " + GameState.Menu);
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // If there is already a game manager, destroy the new one
            Destroy(gameObject);
        }
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
}