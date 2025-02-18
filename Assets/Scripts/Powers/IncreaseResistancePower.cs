using UnityEngine;

public class IncreaseResistancePower : IPower
{
    public int resistanceIncrease = 10;
    public float cooldown = 10f;
    public float Cooldown => cooldown;
    public void Activate(Entity entity)
    {
        Debug.Log($"IncreaseResistance is activated and increase resistance by {resistanceIncrease}");
    }
}