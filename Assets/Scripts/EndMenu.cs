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

    // Start is called before the first frame update
    void Awake()
    {
        GameManager.OnStateChange += OnStateChange;
    }

    void Start()
    {
        int winner = GameManager.instance.Winner;
        string victoryText = victoryTexts[Random.Range(0, victoryTexts.Count - 1)];
        endText.text = $"Player {winner}" + victoryText;
    }

    void OnDestroy()
    {
        GameManager.OnStateChange -= OnStateChange;
    }

    private void OnStateChange(GameState newState)
    {
        if (newState == GameState.End)
        {
            SoundManager.Instance.PlayMusicTrack("TitleTheme");
        }
    }

    public void ToggleMenu()
    {
        Debug.Log("Going back to menu...");
        GameManager.instance.UpdateState(GameState.Menu);
    }

    public void Quit()
    {
        Debug.Log("Quitting Game...");
        Application.Quit();
    }
}
