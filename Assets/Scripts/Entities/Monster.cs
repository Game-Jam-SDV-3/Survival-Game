using UnityEngine;

public class Monster : Entity
{

    private void Start()
    {
        // Ce monstre a un pouvoir de feu par d�faut
        powerToUse = new FirePower(this);
        AbsorbPower(powerToUse);
    }

    void Attack()
    {
        UsePower(); // Le monstre utilise ses pouvoirs en attaquant
    }

    public void Die()
    {
        Debug.Log("Monstre �limin� !");
        FindObjectOfType<Player>().AbsorbPower(powerToUse); // Le joueur r�cup�re le pouvoir du monstre
        Destroy(gameObject);
    }
}

