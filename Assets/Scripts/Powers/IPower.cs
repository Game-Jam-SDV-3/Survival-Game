using UnityEngine;

public interface IPower
{
    float Cooldown { get; }
    void Activate(Entity entity);
}