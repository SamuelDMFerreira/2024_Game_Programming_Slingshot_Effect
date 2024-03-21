using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    private void Start()
    {
        SoundManager.Instance.PlayMusicTrack("TitleTheme");
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
