using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
	public TextMeshProUGUI dialogueText;
	public Animator animator;
	private Queue<string> sentences;
	public bool startDialogue = false;
	public bool endDialogue=false;

	void Start()
	{
		sentences = new Queue<string>();
	}
	public void StartDialogue(Dialogue dialogue)
	{
		startDialogue = true;
		animator.SetBool("IsOpen", true);
        if (dialogue.name== "Knight")
        {
			Debug.Log("Knight speaks");
        }
		if (dialogue.name == "Archer")
		{
			Debug.Log("Archer speaks");
		}


		sentences.Clear();

		foreach (string sentence in dialogue.sentences)
		{
			sentences.Enqueue(sentence);
		}

		DisplayNextSentence();
	}

	public void DisplayNextSentence()
	{
		if (sentences.Count == 0)
		{
			EndDialogue();
			return;
		}

		string sentence = sentences.Dequeue();
		StopAllCoroutines();
		StartCoroutine(Typing(sentence));
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
		animator.SetBool("IsOpen", false);
		endDialogue = true;
	}

}
