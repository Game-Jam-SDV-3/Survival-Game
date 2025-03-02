using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : Entity
{
    Animator animator;

    public int maxHealth = 100;
    private int currentHealth;

    private void Start()
    {
        animator = GetComponent<Animator>();
        currentHealth = maxHealth;
    }

    void Update()
    {
        if (Input.GetMouseButton(0) && !isAttacking)
        {
            Attack();
        }

        if (Input.GetKeyDown(KeyCode.Space) && !isAttacking)
        {
            UsePower();
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

        SceneManager.LoadScene("Test_Pouvoir");
    }

    private void Attack()
    {
        isAttacking = true;
        animator.SetTrigger("Attack");
        StartCoroutine(ResetAttackCooldown());
    }

    public override void UsePower()
    {
        if (powers.Count > 0 && cooldown <= 0){

            StartCoroutine(CooldownTimer(powers[0].Cooldown));
            powers[0].Activate(this);
            RemovePower(powers[0]);
        }
        Debug.Log("Power used");
    }

    IEnumerator ResetAttackCooldown()
    {
        yield return new WaitForSeconds(1f);
        isAttacking = false;
        canDamage = true;
    }
}
