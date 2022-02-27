using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelLoader : MonoBehaviour
{

    public Animator transition;
    public GameObject dialogueManager;
    private float moveTime = 4f;
    private void Start()
    {
        moveTime += Time.time;
    }
    // Update is called once per frame
    void Update()
    {
        if (dialogueManager == null)
        {

            return;
        }
        if ((!dialogueManager.GetComponent<TriggerDialogue>().levelStarted 
            || EnemyCount.instance.count == 0) && 
            !dialogueManager.GetComponent<DialogueManager>().startDialogue)
        {
            if (Time.time <= moveTime)
            {

                return;
            }



            dialogueManager.GetComponent<TriggerDialogue>().DialogueTrigger();
        }
        if (dialogueManager.GetComponent<TriggerDialogue>().levelEnded)
        {
            LoadNextLevel();
        }
    }

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        yield return new WaitForSeconds(3f);
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(levelIndex);
    }
}
