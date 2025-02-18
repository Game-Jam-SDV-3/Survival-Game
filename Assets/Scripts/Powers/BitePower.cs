using UnityEngine;

public class BitePower : IPower
{
    public int damage = 10;
    public void Activate()
    {
        Debug.Log($"Bite is activated and deal {damage} damage");
    }
}