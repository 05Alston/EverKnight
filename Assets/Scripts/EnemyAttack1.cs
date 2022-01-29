using UnityEngine;

public class EnemyAttack1 : MonoBehaviour
{
    public Transform attackPoint;
    public float attackRange;
    public LayerMask AllyLayer;
    public float attackRate = 1f;
    private float nextAttackTime = 0f;


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

        // Detect enemy in range
        Collider2D[] hitAllies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, AllyLayer);


        // Damage enemy
        foreach (BoxCollider2D ally in hitAllies)
        {
            Debug.Log("Ally Found");
            ally.GetComponent<PlayerHealth>().TakeDamage();
            nextAttackTime = Time.time + 1f / attackRate;
        }
    }

    //Draw wireFrame(*Only visible in the editor)
    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
