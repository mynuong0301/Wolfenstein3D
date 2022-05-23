using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalHealth : MonoBehaviour
{
    public GameObject healthDisplay;
    public static int healthValue;
    public int maxHealth = 100;
    public int internalHealth;
    public Slider healthSlider;
    public GameObject playerDiedPanel;

    // Start is called before the first frame update
    void Start()
    {
        healthValue = maxHealth;
        healthSlider.maxValue = maxHealth;
        healthSlider.value = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (healthValue <= 0)
        {
            healthValue = 0;
            playerDiedPanel.SetActive(true);
        }
        internalHealth = healthValue;
        SetHealth(healthValue);
        healthDisplay.GetComponent<Text>().text = "" + internalHealth;
    }

    public static void changeHealth(int value)
    {
        healthValue += value;
    }

    public void SetHealth(int health)
    {
        healthSlider.value = health;
    }
}
