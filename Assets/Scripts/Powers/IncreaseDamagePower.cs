using UnityEngine;

public class IncreaseDamagePower : IPower
{
    public int damageIncrease = 20;

    public float cooldown = 10f;
    public float Cooldown => cooldown;

    public string Name => "Increase Damage";
    public void Activate(Entity entity)
    {
        Debug.Log($"IncreaseDamage is activated and increase damage by {damageIncrease}");
    }
}