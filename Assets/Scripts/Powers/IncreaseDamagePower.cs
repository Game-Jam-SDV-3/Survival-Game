using UnityEngine;

public class IncreaseDamagePower : IPower
{
    public int damageIncrease = 10;
    public void Activate()
    {
        Debug.Log($"IncreaseDamage is activated and increase damage by {damageIncrease}");
    }
}