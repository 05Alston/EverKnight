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
    {
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
        if (health <= 0)
        {
            Die();
        }
        else
        {
            health --;
        }
        // Play hurt animation
        animator.SetTrigger("isHurt");
        // Move player back on hit
        gameObject.transform.position -= new Vector3(transform.position.x - 5, transform.position.y, transform.position.z);
    }

    private void Die()
    {
        // TODO: Play die animation
        animator.SetBool("isDead", true);
        Debug.Log("You Died");
        // TODO: Disable/Destroy enemy
    }
}
