using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{


    public void loadLevel(string level)
    {
        Debug.Log("attempting to load" + level + "...");
        SceneManager.LoadScene(level);
    }

    public void QuitGame()
    {
        Debug.Log("attemting to quit ...");
        Application.Quit();
    }
}
