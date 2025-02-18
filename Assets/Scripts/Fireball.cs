using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float speed = 10f;  // Vitesse de la boule
    public int damage = 50;    // Dégâts infligés
    public float lifetime = 5f; // Durée avant destruction automatique
    private Entity owner; // Référence vers l'entité qui a invoqué la fireball

    public void SetOwner(Entity entity)
    {
        owner = entity; // Définit le propriétaire
    }

    private void Start()
    {
        Destroy(gameObject, lifetime); // Détruit la boule après un certain temps
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime); // Déplacement en ligne droite
    }

    private void OnTriggerEnter(Collider other)
    {
        Entity entity = other.GetComponent<Entity>();

        // Vérifie que l'entité touchée N'EST PAS le propriétaire
        if (entity != null && entity != owner)
        {
            entity.TakeDamage(damage);
            Debug.Log($"{other.name} a pris {damage} dégâts !");
            Destroy(gameObject); // Détruit la boule après impact
        }
        else if (entity == owner)
        {
            Debug.Log("La fireball a touché son propriétaire, mais aucun dégât !");
        }
    }
}