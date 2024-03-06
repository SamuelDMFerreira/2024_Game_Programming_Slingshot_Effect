using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void ToggleOnline()
    {
        GameManager.instance.UpdateState(GameState.Online);
    }

    public void ToggleLocal()
    {
        GameManager.instance.UpdateState(GameState.Local);
    }

    public void Quit()
    {
        Debug.Log("Quitting Game...");
        Application.Quit();
    }
}
