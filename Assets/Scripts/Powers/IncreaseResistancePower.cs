using UnityEngine;

public class IncreaseResistancePower : IPower
{
    public int resistanceIncrease = 10;
    public void Activate()
    {
        Debug.Log($"IncreaseResistance is activated and increase resistance by {resistanceIncrease}");
    }
}