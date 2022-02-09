using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public Joystick joystick;
    Vector2 movement;
    private Animator animator;
    private GameObject dialogueManager;


    private void Start()
    {
        animator = GetComponent<Animator>();
        dialogueManager = GameObject.FindGameObjectWithTag("DialogueManager");
    }
    // Update is called once per frame
    void Update()
    {

        if (dialogueManager.GetComponent<TriggerDialogue>().levelEnded)
        {
            animator.SetFloat("Horizontal", 1);
            animator.SetFloat("Vertical", 0);
            animator.SetFloat("Speed", 1);
            transform.position = new Vector3(transform.position.x + 0.03f, transform.position.y, transform.position.z);
            return;
        }
        movement.x = joystick.Horizontal;
        movement.y = joystick.Vertical;
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }
}
