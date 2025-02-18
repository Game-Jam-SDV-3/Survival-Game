using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Monster : Entity
{
    protected IPower powerToUse;
    private Transform player;
    private NavMeshAgent agent;
    private Animator animator;

    public float detectionRange = 10f;
    public float attackRange = 2f;

    private bool isChasing = false;
    private bool isDead = false;
    protected void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        if (powerToUse != null)
        {
            AbsorbPower(powerToUse);
        }

        // Trouver le joueur au démarrage
        Player foundPlayer = Object.FindFirstObjectByType<Player>();
        if (foundPlayer != null)
        {
            player = foundPlayer.transform;
        }
    }

    void Update()
    {
        if (player != null && !isDead)
        {
            float distance = Vector3.Distance(transform.position, player.position);

            if (distance <= detectionRange)
            {
                ChasePlayer();
                animator.SetTrigger("Chase");
                animator.SetBool("Lost Player", false);

            }

            if (distance <= attackRange && !isAttacking)
            {
                Attack();
            }
        }
    }

    private void ChasePlayer()
    {
        if (agent != null && agent.isOnNavMesh && player != null)
        {
            float distance = Vector3.Distance(transform.position, player.position);

            if (distance > attackRange)
            {
                agent.SetDestination(player.position);
            }
            else
            {
                agent.ResetPath();
                Attack();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Joueur détecté !");
        }
    }

    public void Attack()
    {
        Debug.Log("Attaque du monstre !");
        isAttacking = true;
        animator.SetTrigger("Attack");
        ResetAttackCooldown();
        UsePower();
    }

    IEnumerator ResetAttackCooldown()
    {
        yield return new WaitForSeconds(1f);
        isAttacking = false;
        canDamage = true;
    }

    public override void Die()
    {
        Debug.Log("Monstre éliminé !");
        Player player = Object.FindFirstObjectByType<Player>();
        isDead = true;
        agent.isStopped = true;
        if (player != null && powerToUse != null)
        {
            player.AbsorbPower(powerToUse);
        }
        animator.SetTrigger("Dead");
        Destroy(gameObject, 5f);

    }
}
