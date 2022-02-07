using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelLoader : MonoBehaviour
{
    
    public Animator transition;
    public float delay =1f;
    // Update is called once per frame
    void Update()
    {
        if (EnemyCount.instance.count == 0){
            LoadNextLevel();
        }
    }

    public void LoadNextLevel(){
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex+1));
    }

    IEnumerator LoadLevel(int levelIndex){
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(levelIndex);
    }
}
