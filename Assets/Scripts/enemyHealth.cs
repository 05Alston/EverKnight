using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    public float maxHealth = 10;
    public float currentHealth;
    [SerializeField] public HealthBar healthBar;// Healthbar will have value between 0 and 1



    void Start()
    {
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
    }

    private void Die()
    {
        // TODO: Play die animation
        Debug.Log("Enemy Dead");
        // TODO: Disable/Destroy enemy
    }
}
