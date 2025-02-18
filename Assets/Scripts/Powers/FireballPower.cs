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

        // Cr�e la boule de feu � la position du joueur
        GameObject fireballObj = Object.Instantiate(fireballPrefab, entity.transform.position + entity.transform.forward * 1.5f, entity.transform.rotation);

        // R�cup�re le script Fireball et assigne le propri�taire
        Fireball fireball = fireballObj.GetComponent<Fireball>();
        if (fireball != null)
        {
            fireball.SetOwner(entity);
        }

        Debug.Log($"{entity.name} a lanc� une boule de feu !");
    }
}
