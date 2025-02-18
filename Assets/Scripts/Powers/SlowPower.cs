using UnityEngine;

public class SlowPower : IPower
{
    public float cooldown = 10f;
    public float Cooldown => cooldown;
    public void Activate(Entity entity)
    {
        Debug.Log($"Slow is activated and slow ennemies");
    }
}