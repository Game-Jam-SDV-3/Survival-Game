using UnityEngine;

public class FireballPower : IPower
{
    
    private GameObject fireballPrefab = Resources.Load<GameObject>("FireballPrefab");
    public float cooldown = 3f; // Temps de recharge entre deux tirs
    public float Cooldown => cooldown;

    public string Name => "Fireball";
    
    public void Activate(Entity entity)
    {
        if (entity == null || fireballPrefab == null)
        {
            Debug.LogWarning("FireballPower: entity or fireballPrefab is null");
            return;
        }

        // Crée la boule de feu à la position du joueur
        GameObject fireballObj = Object.Instantiate(fireballPrefab, entity.transform.position + entity.transform.forward * 1.5f, entity.transform.rotation);

        // Récupère le script Fireball et assigne le propriétaire
        Fireball fireball = fireballObj.GetComponent<Fireball>();
        if (fireball != null)
        {
            fireball.SetOwner(entity);
        }

        Debug.Log($"{entity.name} a lancé une boule de feu !");
    }
}
