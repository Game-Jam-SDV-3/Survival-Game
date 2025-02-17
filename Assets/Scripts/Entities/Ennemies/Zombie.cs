using UnityEngine;

public class Zombie : Monster
{
    new private void Start()
    {
        base.Start();

        Initialize(10, 2f, 70);
        powerToUse = new BitePower(); 
        AbsorbPower(powerToUse);
    }
}