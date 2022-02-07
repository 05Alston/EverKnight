using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDialogue : MonoBehaviour
{
    public Dialogue[] dialogues;
    public void DialogueTrigger()
    {
        foreach (Dialogue dialogue in dialogues)
        {
            GetComponent<DialogueManager>().StartDialogue(dialogue);
        }
    }


}
