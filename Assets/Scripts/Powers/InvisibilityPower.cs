using UnityEngine;

public class InvisibilityPower : IPower
{
    public void Activate()
    {
        Debug.Log($"Invisibility is activated and make the player invisible");
    }
}