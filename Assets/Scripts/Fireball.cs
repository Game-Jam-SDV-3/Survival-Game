using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float speed = 10f;  // Vitesse de la boule
    public int damage = 50;    // D�g�ts inflig�s
    public float lifetime = 5f; // Dur�e avant destruction automatique
    private Entity owner; // R�f�rence vers l'entit� qui a invoqu� la fireball

    public void SetOwner(Entity entity)
    {
        owner = entity; // D�finit le propri�taire
    }

    private void Start()
    {
        Destroy(gameObject, lifetime); // D�truit la boule apr�s un certain temps
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime); // D�placement en ligne droite
    }

    private void OnTriggerEnter(Collider other)
    {
        Entity entity = other.GetComponent<Entity>();

        // V�rifie que l'entit� touch�e N'EST PAS le propri�taire
        if (entity != null && entity != owner)
        {
            entity.TakeDamage(damage);
            Debug.Log($"{other.name} a pris {damage} d�g�ts !");
            Destroy(gameObject); // D�truit la boule apr�s impact
        }
        else if (entity == owner)
        {
            Debug.Log("La fireball a touch� son propri�taire, mais aucun d�g�t !");
        }
    }
}