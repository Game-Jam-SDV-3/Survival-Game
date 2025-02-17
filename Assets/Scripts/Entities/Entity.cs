using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public List<IPower> powers = new List<IPower>();
    public int damage = 10;
    public float speed = 5;

    public void AbsorbPower(IPower newPower)
    {
        powers.Add(newPower);
        newPower.Activate();
    }

    public void RemovePower(IPower power)
    {
        if (powers.Contains(power))
        {
            power.Deactivate();
            powers.Remove(power);
        }
    }

    public void UsePower()
    {
        foreach (IPower power in powers)
        {
            power.Activate(); // Chaque pouvoir a sa logique d'activation
        }
    }

    protected void Move(Vector3 dir)
    {
        transform.Translate(dir * speed * Time.deltaTime);
    }
}

