using System.Collections.Generic;
using System.Collections;
using UnityEngine;
public abstract class Entity : MonoBehaviour
{
    public List<IPower> powers = new List<IPower>();
    public int damage = 10;
    public float speed = 5;
    public int health = 100;
    public bool isAttacking = false;
    public bool canDamage = true;
    
    protected float cooldown = 0f;
    public void Initialize(int newDamage, float newSpeed, int newHealth)
    {
        damage = newDamage;
        speed = newSpeed;
        health = newHealth;
    }

    public void AbsorbPower(IPower newPower)
    {
        powers.Add(newPower);
        Debug.Log($"{name} has absorbed a power: {newPower.Name}");
    }

    public void RemovePower(IPower power)
    {
        if (powers.Contains(power))
        {
            powers.Remove(power);
        }
    }

    public abstract void UsePower();

    protected IEnumerator CooldownTimer(float powerCooldown)
    {
        cooldown = powerCooldown;
        while (cooldown > 0)
        {
            cooldown -= Time.deltaTime;
            yield return null;
        }
        cooldown = 0;

    }

    protected void Move(Vector3 dir)
    {
        transform.Translate(dir * speed * Time.deltaTime);
    }

    public abstract void Die();

    public void TakeDamage(int damage)
    {
        health -= damage;

        Debug.Log($"{name} took {damage} damage and now have {health} health");

        if (health <= 0)
        {
            Die();
        }
    }
}
