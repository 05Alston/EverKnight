using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDialogue : MonoBehaviour
{
    public Dialogue[] LevelStartDialogues;
    public Dialogue[] LevelEndDialogues;
    private GameObject player;
    private GameObject ally;
    private GameObject[] enemies;
    public Actor[] actors;
    public bool levelStarted = false;
    public bool levelEnded = false;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        ally = GameObject.FindGameObjectWithTag("Ally");
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
    }
    public void DialogueTrigger()
    {
        //Inputs(true);
        levelStarted = true;
        if (EnemyCount.instance.count == 0)
        {
            if (levelEnded)
            {
                return;
            }
            Inputs(false);
            GetComponent<DialogueManager>().StartDialogue(LevelEndDialogues, actors);
            levelEnded = true;
            return;
        }
        GetComponent<DialogueManager>().StartDialogue(LevelStartDialogues, actors);

    }
    public void Inputs(bool enable)
    {
        foreach (GameObject enemy in enemies)
        {
            enemy.GetComponent<EnemyFollow>().enabled = enable;
        }
        player.GetComponent<PlayerAnimation>().enabled = enable;
        player.GetComponent<PlayerMovement>().enabled = enable;
        player.GetComponent<PlayerAttack>().enabled = enable;
        ally.GetComponent<AllyAttack>().enabled = enable;
    }
}
[System.Serializable]
public class Actor
{
    public string name;
    public Sprite sprite;
}


[System.Serializable]
public class Dialogue
{
    public int actorId;
    [TextArea(1, 4)]
    public string sentence;
}
