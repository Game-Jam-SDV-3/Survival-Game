using System.Collections.Generic;
using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    public List<IPower> powers = new List<IPower>();
    public int damage = 10;
    public float speed = 5;
    public int health = 100;

    public void Initialize(int newDamage, float newSpeed, int newHealth)
    {
        damage = newDamage;
        speed = newSpeed;
        health = newHealth;
    }

    public void AbsorbPower(IPower newPower)
    {
        powers.Add(newPower);
        newPower.Activate();
    }

    public void RemovePower(IPower power)
    {
        if (powers.Contains(power))
        {
            powers.Remove(power);
        }
    }

    public void UsePower()
    {
        foreach (IPower power in powers)
        {
            power.Activate();
        }
    }

    protected void Move(Vector3 dir)
    {
        transform.Translate(dir * speed * Time.deltaTime);
    }

    public abstract void Die();

    public void TakeDamage(int damage)
    {
        health -= damage;

        Debug.Log("Monstre touché ! PV: " + health);

        if (health <= 0)
        {
            Die();
        }
    }
}
