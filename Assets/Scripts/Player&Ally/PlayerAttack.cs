using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Animator animator;
    public float attackRange;
    public LayerMask enemyLayer;
    public int attackDamage;
    public float attackRate = 2f;
    private float nextAttackTime = 0f;
    private bool isAttackTime = true;


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
            isAttackTime = true;

        }


    }
    public void Attack()
    {
        if (animator.GetBool("isDead"))
        {
            return;
        }
        if (!isAttackTime)
        {
            return;
        }
        // Put attack animation
        animator.SetTrigger("Attack");
        FindObjectOfType<AudioManager>().Play("Attack");
        // Detect enemy in range
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, attackRange, enemyLayer);

        // Damage enemy
        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log("Enemies found");
            enemy.GetComponent<EnemyHealth>().TakeDamage(attackDamage);
        }
        isAttackTime = false;
        nextAttackTime = Time.time + 1f / attackRate;

    }

    private void OnDrawGizmosSelected()
    {

        Gizmos.DrawWireSphere(transform.position, attackRange);
    }


}
