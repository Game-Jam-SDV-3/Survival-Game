using UnityEngine;

public class InvisibilityPower : IPower
{
    public float cooldown = 10f;
    public float Cooldown => cooldown;
    public void Activate(Entity entity)
    {
        Debug.Log($"Invisibility is activated and make the player invisible");
    }
}