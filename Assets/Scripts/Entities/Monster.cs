using UnityEngine;

public class Monster : MonoBehaviour
{
    public IPower power;

    public void UsePower()
    {
        if (power != null)
            power.Activate();
    }

    public IPower DropPower()
    {
        return power;
    }
}
