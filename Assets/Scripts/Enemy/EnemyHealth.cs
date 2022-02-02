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
        animator = gameObject.GetComponent<Animator>();
        currentHealth = maxHealth;
        healthBar.SetHealth(maxHealth / maxHealth);
    }

    public void TakeDamage(int damage)
    {
        gameObject.GetComponent<EnemyFollow>().delay = 0;
        currentHealth -= damage;
        if (currentHealth <=0)
        {
            Die();
        }
        healthBar.SetHealth(currentHealth / maxHealth);


        // TODO: Play hurt animation
        // Move enemy back on hit
        gameObject.transform.position = new Vector3(gameObject.transform.position.x + 0.8f, gameObject.transform.position.y, gameObject.transform.position.z);


    }

    private void Die()
    {
        // Disable enemy
        gameObject.layer = 3;
        gameObject.GetComponent<EnemyFollow>().enabled = false;
        gameObject.GetComponent<EnemyAttack1>().enabled = false;
        // Play die animation
        animator.SetBool("isDead", true);
        Debug.Log("Enemy Dead");
    }


}
