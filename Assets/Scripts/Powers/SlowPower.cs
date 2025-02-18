using UnityEngine;

public class SlowPower : IPower
{
    public float cooldown = 10f;
    public float Cooldown => cooldown;

    public string Name => "Slow";
    public void Activate(Entity entity)
    {
        Debug.Log($"Slow is activated and slow ennemies");
    }
}