using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public int tutorialDone;
    public GameObject tutorial;
    void Start()
    {

        tutorialDone = PlayerPrefs.GetInt("Tutorial", 0);

        //get int return int in tutorial but it doesnt exist in 1st run so defualt value is 0
        //in 2nd run it gets 1
    }

    public void PlayGame()
    {
        if (tutorialDone != 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            return;
        }
        tutorial.SetActive(true);
        PlayerPrefs.SetInt("Tutorial", 1);
        //now 1 is stored in tut 
        tutorialDone = 1;
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
