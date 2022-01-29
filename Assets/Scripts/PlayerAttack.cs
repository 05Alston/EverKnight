using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Transform attackPoint;
    public float attackRange;
    public LayerMask enemyLayer;
    public int attackDamage;
    public float attackRate =2f;
    private float nextAttackTime = 0f;


    // TODO: Attack when clicked on right half of screen

    void Update()
    {
        // Added delay between attacks
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Attack();
                nextAttackTime = Time.time+ 1f/attackRate;
            }
        }
        
    }
    private void Attack()
    {
        // Put attack animation

        // Detect enemy in range
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);

        // Damage enemy
        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log("Enemies found");
            enemy.GetComponent<enemyHealth>().TakeDamage(attackDamage);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }


}
