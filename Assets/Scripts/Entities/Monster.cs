using UnityEngine;

public class Monster : Entity
{
    public IPower powerToUse;

    private void Start()
    {
        // Ce monstre a un pouvoir de feu par défaut
        powerToUse = new FirePower(this);
        AbsorbPower(powerToUse);
    }

    void Attack()
    {
        UsePower(); // Le monstre utilise ses pouvoirs en attaquant
    }

    public void Die()
    {
        Debug.Log("Monstre éliminé !");
        FindObjectOfType<Player>().AbsorbPower(powerToUse); // Le joueur récupère le pouvoir du monstre
        Destroy(gameObject);
    }
}

