using System.Collections;
using UnityEngine;

public class WeaponCollider : MonoBehaviour
{
    public GameObject hitEffect;
    public Player player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy") && player.isAttacking && player.canDamage)
        {
            other.GetComponent<Monster>().TakeDamage(10);
            player.canDamage = false;

            GameObject bloodEffect = Instantiate(hitEffect, new Vector3(other.transform.position.x, other.transform.position.y + 2, other.transform.position.z), other.transform.rotation);

            Destroy(bloodEffect, 2f);
        }
    }
}
