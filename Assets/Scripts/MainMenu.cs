using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    void Awake()
    {
        GameManager.OnStateChange += OnStateChange;
    }

    void OnDestroy()
    {
        GameManager.OnStateChange -= OnStateChange;
    }

    private void OnStateChange(GameState newState)
    {
        if (newState == GameState.Menu)
        {
            SoundManager.Instance.PlayMusicTrack("TitleTheme");
        }
    }

    public void PlayGame()
    {
        Debug.Log("Starting Game...");
        GameManager.instance.UpdateState(GameState.Play);
    }

    public void Quit()
    {
        Debug.Log("Quitting Game...");
        Application.Quit();
    }
}
