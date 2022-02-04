using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyAttack : MonoBehaviour
{
    public Animator animator;
    public float attackRange=15;
    public int attackDamage;
    public GameObject arrowPrefab;
    public LayerMask enemyLayer;
    public float allyAttackRate = 4f;
    private float nextAttackTime = 5f;


    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            Attack();
        }
        

    }

    private void Attack()
    {
        // Put attack animation
        animator.SetTrigger("Attack");

        // Create Prefab
        Invoke("InstantiateMethod", 0.75f);
        nextAttackTime = Time.time + 1f / allyAttackRate;
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
