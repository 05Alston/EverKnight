using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyAttack : MonoBehaviour
{
    public float attackRange=15;
    public int attackDamage;
    public GameObject target;
    private GameObject arrowPrefab;
    public LayerMask enemyLayer;
    public float attackRate = 0.2f;
    private float nextAttackTime = 0f;

    // Update is called once per frame
    void Update()
    {
        arrowPrefab = GameObject.FindGameObjectWithTag("Arrow");
        Instantiate(arrowPrefab, transform.position ,arrowPrefab.transform.rotation);

    }

    private void Attack()
    {
        // Put attack animation

        // Detect enemy in range
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, attackRange, enemyLayer);

        // Damage enemy
        foreach (Collider2D enemy in hitEnemies)
        {
            while(enemy.GetComponent<EnemyHealth>().currentHealth >= 0)
            {
                enemy.GetComponent<EnemyHealth>().TakeDamage(attackDamage);
                nextAttackTime = Time.time + 1f / attackRate;
            }

        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }

}
