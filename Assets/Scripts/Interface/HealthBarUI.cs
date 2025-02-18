using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    public Image healthFill;

    public void SetMaxHealth(int maxHealth)
    {
        healthFill.fillAmount = 1;
    }

    public void SetHealth(int health, int maxHealth)
    {
        healthFill.fillAmount = (float)health / maxHealth;
    }
}