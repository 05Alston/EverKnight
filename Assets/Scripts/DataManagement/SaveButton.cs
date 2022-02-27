using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveButton : MonoBehaviour
{
    public void SaveInfo()
    {
        PlayerPrefs.SetInt("currentLevel", SceneManager.GetActiveScene().buildIndex);
    }
}
