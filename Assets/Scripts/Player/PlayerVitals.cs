using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerVitals : MonoBehaviour
{
    public Slider healthBar;
    public TextMeshProUGUI healthPercentageText;
    public int maxHealth;
    public int healthOverTime;

    public Slider hungerBar;
    public TextMeshProUGUI hungerPercentageText;
    public int maxHunger;
    public int hungerOverTime;

    public Slider thirstBar;
    public TextMeshProUGUI thirstPercentageText;
    public int maxThirst;
    public int thirstOverTime;

    void Start()
    {
        healthBar.maxValue = maxHealth;
        healthBar.value = maxHealth;
        healthPercentageText.text = maxHealth + "%";

        hungerBar.maxValue = maxHunger;
        hungerBar.value = maxHunger;
        hungerPercentageText.text = maxHunger + "%";

        thirstBar.maxValue = maxThirst;
        thirstBar.value = maxThirst;
        thirstPercentageText.text = maxThirst + "%";
    }

    void Update()
    {
        //Health
        if (hungerBar.value <= 0 && (thirstBar.value <= 0))
        {
            healthBar.value = Time.deltaTime / healthOverTime * 2;
            healthPercentageText.text = healthBar.value.ToString("#.") + "%";
        }

        else if (hungerBar.value <= 0 || thirstBar.value <= 0)
        {
            healthPercentageText.text = healthBar.value.ToString("#.") + "%";
            healthBar.value = Time.deltaTime / healthOverTime;
        }

        if (healthBar.value <= 0)
        {
            CharacterDeath();
        }

        //Hunger
        if (hungerBar.value >= 0)
        {
            hungerPercentageText.text = hungerBar.value.ToString("#.") + "%";
            hungerBar.value -= Time.deltaTime / hungerOverTime;
        }

        else if (hungerBar.value >= maxHunger)
        {
            hungerPercentageText.text = hungerBar.value.ToString("#.") + "%";
            hungerBar.value = maxHunger;
        }

        //Thirst
        if (thirstBar.value >= 0)
        {
            thirstPercentageText.text = thirstBar.value.ToString("#.") + "%";
            thirstBar.value -= Time.deltaTime / thirstOverTime;
        }

        else if (thirstBar.value <= 0)
        {
            thirstPercentageText.text = thirstBar.value.ToString("#.") + "%";
            thirstBar.value = 0;
        }

        else if (thirstBar.value >= maxThirst)
        {
            thirstPercentageText.text = thirstBar.value.ToString("#.") + "%";
            thirstBar.value = maxThirst;
        }
    }

    void CharacterDeath()
    {

    }
}
