using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyAttack : MonoBehaviour
{
    public Animator animator;
    public float attackRange=15;
    public int attackDamage;
    public GameObject target;
    private GameObject arrowPrefab;
    public LayerMask enemyLayer;
    public float attackRate = 4f;
    private float nextAttackTime = 0f;

    void Start()
    {
        arrowPrefab = GameObject.FindGameObjectWithTag("Arrow");
    }
    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
        

    }

    private void Attack()
    {
        // Put attack animation
        animator.SetTrigger("Attack");

        // Create Prefab
        Invoke("InstantiateMethod", 0.75f);


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

    private void InstantiateMethod()
    {
        Instantiate(arrowPrefab, transform.position, arrowPrefab.transform.rotation);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }

}
