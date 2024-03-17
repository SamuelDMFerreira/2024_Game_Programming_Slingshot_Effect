using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
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
