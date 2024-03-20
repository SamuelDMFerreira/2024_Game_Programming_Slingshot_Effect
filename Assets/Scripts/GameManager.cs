using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Properties;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private GameObject player1;
    private GameObject player2;
    private SceneController sceneController;
    private int winner;

    public GameState currentState { get; private set; }

    public int Winner { get => winner; }

    // INSTANCE
    public static GameManager instance { get; private set; }

    // EVENTS
    public static event Action<int, float, float> OnHealthChange;
    public static event Action<GameState> OnStateChange;

    void Awake()
    {
        if (GameManager.instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        sceneController = gameObject.AddComponent<SceneController>();
    }

    private void Start()
    {
        this.UpdateState(GameState.Menu);
    }


    public void UpdateState(GameState newState)
    {
        // If the new state is the same as the current state, do nothing
        if (this.currentState == newState)
        {
            return;
        }

        this.currentState = newState;

        switch (newState)
        {
            case GameState.Menu:
                Debug.Log("Loading start scene");
                sceneController.LoadStartScene();
                break;
            case GameState.Play:
                Debug.Log("Loading main scene");
                sceneController.LoadMainScene();
                AddPlayers();
                break;
            case GameState.End:
                Debug.Log("Loading end scene");
                sceneController.LoadEndScene();
                break;
        }

        OnStateChange?.Invoke(newState);
    }

    public void UpdateHealth(int playerID, float currentHealth, float maxHealth)
    {
        Debug.Log("Player " + playerID + " health: " + currentHealth + " / " + maxHealth);
        
        OnHealthChange?.Invoke(playerID, currentHealth, maxHealth);

        if (currentHealth <= 0)
        {
            this.winner = (playerID == 1) ? 2 : 1;
            Debug.Log("Player " + winner + " wins!");

            UpdateState(GameState.End);
        }
    }

    public void AddPlayers()
    {
        player1 = GameObject.FindGameObjectWithTag("Player1");
        player1.SetActive(true);

        player2 = GameObject.FindGameObjectWithTag("Player2");
        player2.SetActive(true);

        this.winner = -1;
    }
}