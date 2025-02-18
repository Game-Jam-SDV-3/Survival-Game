using UnityEngine;

public class IncreaseSpeedPower : IPower
{
    public float speedIncrease = 2f;
    public float cooldown = 10f;
    public float Cooldown => cooldown;
    public void Activate(Entity entity)
    {
        Debug.Log($"IncreaseSpeed is activated and increase speed by {speedIncrease}");
    }
}