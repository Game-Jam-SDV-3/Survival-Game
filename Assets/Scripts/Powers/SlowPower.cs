using UnityEngine;

public class SlowPower : IPower
{
    public void Activate()
    {
        Debug.Log($"Slow is activated and slow ennemies");
    }
}