using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnnemiHealthBarUI : MonoBehaviour
{
    public Image healthFill;
    public Monster monster;
    public int maxHealth;

    void Start()
    {
        maxHealth = monster.health;
        healthFill.fillAmount = monster.health / maxHealth;
    }

    void Update()
    {
        healthFill.fillAmount = (float)monster.health / maxHealth;
    }
}