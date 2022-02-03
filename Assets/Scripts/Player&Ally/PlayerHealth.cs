using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    private Animator animator;
    public int health;
    public int numOfHearts;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite halfHeart;
    public Sprite emptyHeart;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void Update()
    {// Each heart is 2 lives
        health = (health <= numOfHearts*2) ? health : numOfHearts*2;

        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].sprite = (i < health/2) ? fullHeart:((i-1<health/2 && health%2==1) ?halfHeart: emptyHeart) ;
            hearts[i].enabled = (i < numOfHearts);
        }
    }
    public void TakeDamage()
    {
        Debug.Log("Took Damage");
        health--;
        if (health <= 0)
        {
            Die();
        }
        // Play hurt animation
        animator.SetTrigger("isHurt");
        
        // Move player back on hit
        gameObject.transform.position = new Vector3(gameObject.transform.position.x - 0.8f, gameObject.transform.position.y, gameObject.transform.position.z);
    }

    private void Die()
    {
        // TODO: Play die animation
        animator.SetBool("isDead", true);
        // Disable/Destroy player
        gameObject.layer = 3;
        gameObject.GetComponent<PlayerMovement>().enabled = false;
        gameObject.GetComponent<PlayerAttack>().enabled = false;
        gameObject.GetComponent<PlayerHealth>().hearts[0].sprite = emptyHeart;
        gameObject.GetComponent<PlayerHealth>().enabled = false;
        Debug.Log("You Died");
        // TODO: End Screen
    }
}