using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Animator animator;
    public float attackRange;
    public LayerMask enemyLayer;
    public int attackDamage;
    public float attackRate =2f;
    private float nextAttackTime = 0f;


    // TODO: Attack when clicked on right half of screen
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
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
        animator.SetTrigger("Attack");
        // Detect enemy in range
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, attackRange, enemyLayer);

        // Damage enemy
        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log("Enemies found");
            enemy.GetComponent<EnemyHealth>().TakeDamage(attackDamage);
        }
    }

    private void OnDrawGizmosSelected()
    {

        Gizmos.DrawWireSphere(transform.position, attackRange);
    }


}
