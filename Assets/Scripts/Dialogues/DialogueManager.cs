using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public Animator animator;
    public Image image;
    public bool startDialogue = false;
    Dialogue[] currentDialogues;
    Actor[] currentActors;
    int activeMessage = 0;



    public void StartDialogue(Dialogue[] dialogues, Actor[] actors)
    {
        currentDialogues = dialogues;
        currentActors = actors;
        activeMessage = 0;
        if (currentDialogues.Length == 0)
        {
            Debug.Log("Sup MOFO!");
            EndDialogue();
            return;
        }
        DisplayDialogue();
    }

    public void DisplayDialogue()
    {
        startDialogue = true;
        animator.SetBool("IsOpen", true);
        Dialogue dialogueToDisplay = currentDialogues[activeMessage];
        Actor actorToDisplay = currentActors[dialogueToDisplay.actorId];
        image.sprite = actorToDisplay.sprite;
        StartCoroutine(Typing(dialogueToDisplay.sentence));
    }

    public void DisplayNextSentence()
    {
        StopAllCoroutines();
        activeMessage++;
        if (activeMessage < currentDialogues.Length)
        {
            DisplayDialogue();
            return;
        }
        else
        {
            EndDialogue();
            return;
        }
    }

    IEnumerator Typing(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    void EndDialogue()
    {
        if (EnemyCount.instance.count == 0)
        {
            GetComponent<TriggerDialogue>().levelEnded = true;
        }
        startDialogue = false;
        GetComponent<TriggerDialogue>().Inputs(true);
        animator.SetBool("IsOpen", false);
    }

}