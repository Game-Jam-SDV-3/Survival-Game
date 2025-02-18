using UnityEngine;

public interface IPower
{
    float Cooldown { get; }
    string Name { get; }
    void Activate(Entity entity);
}