using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    public Image healthFill;
    public TMP_Text healthText;

    public Player player;

    void Start()
    {
        healthFill.fillAmount = player.health / player.maxHealth;
        healthText.text = player.health.ToString();
    }

    void Update()
    {
        healthFill.fillAmount = (float)player.health / player.maxHealth;
        healthText.text = player.health.ToString();
    }

    public void SetMaxHealth(int maxHealth)
    {
        healthFill.fillAmount = 1;
        player.maxHealth = maxHealth;
    }
}