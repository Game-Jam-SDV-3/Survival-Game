using System.Collections;
using UnityEngine;

public class WeaponCollider : MonoBehaviour
{
    public GameObject hitEffect;
    public Entity entity;  // Assure-toi que cette r�f�rence est bien assign�e
    public string enemyTag;

    private void OnTriggerEnter(Collider other)
    {
        Entity enemyEntity = other.GetComponent<Entity>();

        if (enemyEntity == null)
        {
            Debug.LogWarning("L'entit� attaqu�e n'a pas de script Entity !");
            return;
        }

        if (other.CompareTag(enemyTag) && entity != null && entity.isAttacking && entity.canDamage)
        {
            enemyEntity.TakeDamage(10);
            entity.canDamage = false;

            if (hitEffect != null)
            {
                GameObject bloodEffect = Instantiate(hitEffect, other.transform.position + Vector3.up * 2, other.transform.rotation);
                Destroy(bloodEffect, 2f);
            }
            else
            {
                Debug.LogWarning("hitEffect n'est pas assign� !");
            }
        }
    }
}
