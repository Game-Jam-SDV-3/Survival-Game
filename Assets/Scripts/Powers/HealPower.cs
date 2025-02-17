using UnityEngine;

public class HealPower : IPower
{
    public int health = 50;
    public void Activate()
    {
        Debug.Log($"Heal is activated and heal {health} health");
    }
}