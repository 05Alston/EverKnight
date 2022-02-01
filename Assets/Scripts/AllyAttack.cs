using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyAttack : MonoBehaviour
{
    public Animator animator;
    public float attackRange=15;
    public int attackDamage;
    public GameObject target;
    public GameObject arrowPrefab;
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
            if (Input.GetKeyDown(KeyCode.W))
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
