using UnityEngine;

public class EnemyAttack1 : MonoBehaviour
{
    public float attackRange;
    public LayerMask AllyLayer;
    public float attackRate = 1f;
    private float nextAttackTime = 0f;

    private void Start()
    {
        attackRange = transform.GetComponent<CircleCollider2D>().radius;
    }

    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            Attack();
        }
    }
    private void Attack()
    {
        //Put attack animation

        //Detect enemy in range
        Collider2D[] hitAllies = Physics2D.OverlapCircleAll(transform.position, attackRange, AllyLayer);

        //Damage enemy
        foreach (Collider2D enemy in hitAllies)
        {
            enemy.GetComponent<PlayerHealth>().TakeDamage();
            nextAttackTime = Time.time + 1f / attackRate;
        }
    }
}
