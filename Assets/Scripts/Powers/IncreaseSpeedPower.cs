using UnityEngine;

public class IncreaseSpeedPower : IPower
{
    public float speedIncrease = 2f;
    public void Activate()
    {
        Debug.Log($"IncreaseSpeed is activated and increase speed by {speedIncrease}");
    }
}