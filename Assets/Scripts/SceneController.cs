using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void LoadStartScene()
    {
        SceneManager.LoadScene("Start");
    }
    public void LoadMainScene()
    {
        SceneManager.LoadScene("Slingshot");
    }
    public void LoadEndScene()
    {
        SceneManager.LoadScene("GameOver");
    }
}
