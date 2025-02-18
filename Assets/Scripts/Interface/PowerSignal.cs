using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PowerSignal : MonoBehaviour
{
    public Image powerImage;
    public TMP_Text powerText;

    public Player player;

    void Start()
    {
        powerImage.gameObject.SetActive(false);
        powerText.gameObject.SetActive(false);
    }

    void Update()
    {
        if (player.powers.Count > 0)
        {
            if (player.cooldown <= 0)
            {
                powerImage.color = Color.white;
                powerText.text = "";
            }
            else
            {
                powerImage.color = new Color(0.2f, 0.2f, 0.2f, 1f);
                powerText.text = Mathf.Ceil(player.cooldown).ToString(); 
            }

            powerImage.gameObject.SetActive(true);
            powerText.gameObject.SetActive(true);
        }
        else
        {
            powerImage.gameObject.SetActive(false);
            powerText.gameObject.SetActive(false);
        }
    }
}