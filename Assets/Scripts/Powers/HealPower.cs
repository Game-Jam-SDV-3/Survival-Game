using UnityEngine;

public class HealPower : IPower
{
    public int health = 30;

    public float cooldown = 10f;
    public float Cooldown => cooldown;

    public string Name => "Heal";
    public void Activate(Entity entity)
    {
        if (entity != null)
        {
            entity.health += health;
            Debug.Log($"Heal is activated and heal {health} health");
        }
            
    }
}