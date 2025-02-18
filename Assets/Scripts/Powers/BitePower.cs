using UnityEngine;

public class BitePower : IPower
{
    public int damage = 10;
    public float cooldown = 10f;
    public float Cooldown => cooldown;
    public string Name => "Bite";
    public void Activate(Entity entity)
    {
        Debug.Log($"Bite is activated and deal {damage} damage");
    }
}