using System;
using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using Unity.Properties;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private List<Transform> spawns = new List<Transform>();
    [SerializeField]
    private GameObject playerPrefab;
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
        if (scene.name == "JupiterMap")
        {
            AddPlayers();
        }
    }

    private void AddPlayers()
    {
        player1 = Instantiate(playerPrefab, spawns[0].position, Quaternion.identity);
        player1.GetComponent<PlayerController>().PlayerID = 1;

        // Spawn player 2 at the second spawn point facing the opposite direction
        player2 = Instantiate(playerPrefab, spawns[1].position, Quaternion.Euler(new Vector3(0, 180, 0)));
        player2.GetComponent<PlayerController>().PlayerID = 2;

        // Flip player 2's camera so it's behind the player
        GameObject player2Camera = player2.transform.Find("Player Camera").gameObject;

        Vector3 cameraPosition = player2Camera.transform.localPosition;
        cameraPosition.z = -cameraPosition.z;
        player2Camera.transform.localPosition = cameraPosition;

        this.winner = -1;
    }
}