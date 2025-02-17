using UnityEngine;

public class FirePower : IPower
{
    private Player player;

    public FirePower(Player player)
    {
        this.player = player;
    }

    public void Activate()
    {
        Debug.Log("Pouvoir de feu activé !");
        player.damage += 10; // Exemple d'effet
    }

    public void Deactivate()
    {
        Debug.Log("Pouvoir de feu désactivé !");
        player.damage -= 10;
    }
}
