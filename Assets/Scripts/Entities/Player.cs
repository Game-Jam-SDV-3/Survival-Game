using System.Collections;
using UnityEngine;

public class Player : Entity
{
    Animator animator;
    public bool isAttacking = false;
    public bool canDamage = true;

    public int maxHealth = 100;
    private int currentHealth;

    private void Start()
    {
        animator = GetComponent<Animator>();
        currentHealth = maxHealth;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isAttacking)
        {
            UsePower();
            Attack();
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            TakeDamage(10);
        }

        Vector3 moveDirection = Vector3.zero;

        if (Input.GetKey(KeyCode.Z))
        {
            moveDirection += Vector3.forward;
        }
        if (Input.GetKey(KeyCode.S))
        {
            moveDirection += Vector3.back;
        }
        if (Input.GetKey(KeyCode.Q))
        {
            moveDirection += Vector3.left;
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveDirection += Vector3.right;
        }

        if (moveDirection != Vector3.zero)
        {
            animator.SetBool("isWalking", true);
            if (!isAttacking)
            {
                Move(moveDirection.normalized);
            }
        }
        else
        {
            animator.SetBool("isWalking", false);
        }
    }

    public override void Die()
    {
        Debug.Log("Monstre �limin� !");
        Player player = Object.FindFirstObjectByType<Player>();

        //Destroy(gameObject);
    }

    private void Attack()
    {
        isAttacking = true;
        animator.SetTrigger("Attack");
        StartCoroutine(ResetAttackCooldown());
    }

    IEnumerator ResetAttackCooldown()
    {
        yield return new WaitForSeconds(1f);
        isAttacking = false;
        canDamage = true;
    }
}
