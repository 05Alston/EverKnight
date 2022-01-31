using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    private Animator animator;
    public float maxHealth = 10;
    public float currentHealth;
    [SerializeField] public HealthBar healthBar;// Healthbar will have value between 0 and 1



    void Start()
    {
        //animator = gameObject.GetComponent<Animator>();
        currentHealth = maxHealth;
        healthBar.SetHealth(maxHealth/maxHealth);
    }

    public void TakeDamage(int damage)
    {
        if (currentHealth < 1)
        {
            Die();
        }
        else
        {
            currentHealth -= damage;
        }
        healthBar.SetHealth(currentHealth / maxHealth);


        // TODO: Play hurt animation
        // TODO: Move enemy back on hit
        gameObject.transform.position -= new Vector3(transform.position.x-5,transform.position.y,transform.position.z);


    }

    private void Die()
    {
        // TODO: Play die animation
        animator.SetTrigger("Death");
        GetComponent<Collider2D>().enabled = false;
        GetComponent<EnemyFollow>().enabled = false;
        Debug.Log("Enemy Dead");
        // TODO: Disable/Destroy enemy
    }
}
