using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndMenu : MonoBehaviour
{
    [SerializeField] private TMP_Text endText;

    // Start is called before the first frame update
    void Awake()
    {
        GameManager.OnStateChange += OnStateChange;
    }

    void Start()
    {
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
