using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public Joystick joystick;
    Vector2 movement;
    private Animator animator;
    private GameObject dialogueManager;
    private float moveTime = 3f;


    private void Start()
    {
        animator = GetComponent<Animator>();
        dialogueManager = GameObject.FindGameObjectWithTag("DialogueManager");
    }
    // Update is called once per frame
    void Update()
    {
        if (Time.time <= moveTime)
        {
            animator.SetFloat("Horizontal", 1);
            animator.SetFloat("Vertical", 0);
            animator.SetFloat("Speed", 1);
            transform.position = new Vector3(transform.position.x + 0.05f, transform.position.y, transform.position.z);
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            return;
        }
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
        if (dialogueManager.GetComponent<TriggerDialogue>().levelEnded)
        {
            animator.SetFloat("Horizontal", 1);
            animator.SetFloat("Vertical", 0);
            animator.SetFloat("Speed", 1);
            transform.position = new Vector3(transform.position.x + 0.05f, transform.position.y, transform.position.z);
            return;
        }
        movement.x = joystick.Horizontal;
        movement.y = joystick.Vertical;
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }
}
