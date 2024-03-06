using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void ToggleMenu()
    {
        GameManager.instance.UpdateState(GameState.Menu);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
