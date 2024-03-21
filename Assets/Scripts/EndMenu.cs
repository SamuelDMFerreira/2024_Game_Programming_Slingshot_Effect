using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndMenu : MonoBehaviour
{
    [SerializeField] private TMP_Text endText;
    private static List<string> victoryTexts = new List<string>{
        " secured another victory for the galactic empire!",
        " spread managed democracy throughout the universe!",
        " can't wait to go back to watch some anime.",
        ", ten years from now, will go down in history as the greatest pilot of the era",
        " turned around for a selfie",
    };

    void Start()
    {
        SoundManager.Instance.PlayMusicTrack("TitleTheme");

        int winner = GameManager.instance.Winner;
        string victoryText = victoryTexts[Random.Range(0, victoryTexts.Count - 1)];
        endText.text = $"Player {winner}" + victoryText;
    }

    private void Update()
    {
        if (Input.anyKey)
        {
            RestartGame();
        }
    }

    public void RestartGame()
    {
        Debug.Log("Restarting game...");
        GameManager.instance.UpdateState(GameState.Play);
    }

    public void Quit()
    {
        Debug.Log("Quitting Game...");
        Application.Quit();
    }
}
