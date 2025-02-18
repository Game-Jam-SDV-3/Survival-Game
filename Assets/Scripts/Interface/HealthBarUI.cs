using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    public Image healthFill;

    public Player player;

    void Start()
    {
        healthFill.fillAmount = player.health / player.maxHealth;
    }

    void Update()
    {
        healthFill.fillAmount = (float)player.health / player.maxHealth;
    }

    public void SetMaxHealth(int maxHealth)
    {
        healthFill.fillAmount = 1;
    }
}