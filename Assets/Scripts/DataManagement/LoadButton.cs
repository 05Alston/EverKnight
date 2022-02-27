using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadButton : MonoBehaviour
{
    public MainMenu tutorial;
    public void Load()
    {
        if (PlayerPrefs.HasKey("currentLevel"))
        {
            SceneManager.LoadScene(PlayerPrefs.GetInt("currentLevel"));
            return;
        }
        tutorial.PlayGame();

    }
    public int LoadInfo()
    {
        return PlayerPrefs.GetInt("currentLevel");
    }
}
