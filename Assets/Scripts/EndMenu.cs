using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndMenu : MonoBehaviour
{

    // Start is called before the first frame update
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
        if (newState == GameState.End)
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    public void ToggleMenu()
    {
        GameManager.instance.UpdateState(GameState.Menu);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
