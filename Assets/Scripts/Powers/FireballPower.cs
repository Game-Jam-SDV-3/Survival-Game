using UnityEngine;

public class FireballPower : IPower
{
    public GameObject fireballPrefab;
    public float cooldown = 3f; // Temps de recharge entre deux tirs

    public float Cooldown => cooldown;

    public void Activate(Entity entity)
    {
        if (entity == null || fireballPrefab == null) return;

        // Crée la boule de feu à la position du joueur
        GameObject fireball = Object.Instantiate(fireballPrefab, entity.transform.position + entity.transform.forward * 1.5f, entity.transform.rotation);

        Debug.Log($"{entity.name} a lancé une boule de feu !");
    }
}