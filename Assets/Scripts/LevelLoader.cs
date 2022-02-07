using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelLoader : MonoBehaviour
{
    
    public Animator transition;
    public GameObject dialogueManager;
    // Update is called once per frame
    void Update()
    {
        if (EnemyCount.instance.count == 0&&!dialogueManager.GetComponent<DialogueManager>().startDialogue)
        {
            dialogueManager.GetComponent<TriggerDialogue>().DialogueTrigger();  
        }
        if (dialogueManager.GetComponent<DialogueManager>().endDialogue)
        {
            LoadNextLevel();
        }
    }

    public void LoadNextLevel(){
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex+1));
    }

    IEnumerator LoadLevel(int levelIndex){
        yield return new WaitForSeconds(3f);
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(levelIndex);
    }
}