using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class FirePower : IPower
{
    private Entity entity;

    public FirePower(Entity entity)
    {
        this.entity = entity;
    }

    public void Activate()
    {
        Debug.Log("Pouvoir de feu activ� !");
        entity.damage += 10; // Exemple d'effet
    }

    public void Deactivate()
    {
        Debug.Log("Pouvoir de feu d�sactiv� !");
        entity.damage -= 10;
    }
}
