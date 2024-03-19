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
    [SerializeField]
    private GameObject playerPrefab;
    [SerializeField]
    private List<Transform> spawns = new List<Transform>();

    private int winner;
    private SceneController sceneController;

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
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void Start()
    {
        this.UpdateState(GameState.Menu);
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
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
                this.winner = -1;
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

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Ensure scene is fully loaded before joining players
        if (scene.name == "JupiterMap")
        {
            JoinPlayers();
        }
    }

    private void JoinPlayers()
    {
        GameObject player1 = Instantiate(playerPrefab, spawns[0].position, Quaternion.identity);
        player1.GetComponent<PlayerController>().PlayerNumber = 1;

        // FIXME: Rotating player2 to face player1 will cause it to be behind the camera
        GameObject player2 = Instantiate(playerPrefab, spawns[1].position, Quaternion.identity);
        player2.GetComponent<PlayerController>().PlayerNumber = 2;

        Debug.Log("Total players: " + PlayerInputManager.instance.playerCount);

        for (int i = 0; i < PlayerInputManager.instance.playerCount; i++)
        {
            PlayerInput playerInput = PlayerInput.GetPlayerByIndex(i);
            string playerName = (i == 0) ? "Player 1" : "Player 2";
            Debug.Log(playerName + " connected devices:");

            foreach (InputDevice device in playerInput.devices)
            {
                Debug.Log("- " + device);
            }
        }
    }
}