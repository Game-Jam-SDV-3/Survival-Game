using UnityEngine;

public class Monster : Entity
{
    protected IPower powerToUse;

    protected void Start()
    {
        if (powerToUse != null)
        {
            AbsorbPower(powerToUse);
        }
    }

    public void Attack()
    {
        UsePower();
    }

    public void Die()
    {
        Debug.Log("Monstre éliminé !");
        Player player = Object.FindFirstObjectByType<Player>();
        if (player != null && powerToUse != null)
        {
            player.AbsorbPower(powerToUse);
        }
        Destroy(gameObject);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }
}