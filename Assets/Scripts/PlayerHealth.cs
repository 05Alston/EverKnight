using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int health;
    public int numOfHearts;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite halfHeart;
    public Sprite emptyHeart;

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
        // TODO: Play hurt animation
        // TODO: Move player back on hit
    }

    private void Die()
    {
        // TODO: Play die animation
        Debug.Log("You Died");
        // TODO: Disable/Destroy enemy
    }
}
