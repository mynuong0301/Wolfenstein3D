using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class GlobalHealth : MonoBehaviour
{
    public GameObject healthDisplay;
    public static int healthValue;
    public static bool isDead;
    public int maxHealth = 100;
    public int internalHealth;
    public Slider healthSlider;
    public GameObject deadPanel;
    public GameObject player;
    public Transform respawnPoint;
    public GameObject fillColor;

    // Start is called before the first frame update
    void Start()
    {
        healthValue = maxHealth;
        healthSlider.maxValue = maxHealth;
        healthSlider.value = maxHealth;
        isDead = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (healthValue <= 0 && !isDead)
        {
            healthValue = 0;
            isDead = true;
            if (GlobalLife.lifeValue - 1 >= 0 && isDead)
            {
                StartCoroutine(LifeRecycle());
            }
        }
        internalHealth = healthValue;
        SetHealth(healthValue);
        healthDisplay.GetComponent<Text>().text = "" + internalHealth;
        HP25percent();
    }

    public static void changeHealth(int value)
    {
        healthValue += value;
    }

    public void SetHealth(int health)
    {
        healthSlider.value = health;
    }

    IEnumerator LifeRecycle()
    {
        deadPanel.SetActive(true);
        RespawnCountdown.start = true;
        yield return new WaitForSeconds(5f);
        deadPanel.SetActive(false);
        isDead = false;
        GlobalLife.lifeValue--;
        healthValue = maxHealth;
        player.transform.position = respawnPoint.position;
        player.transform.rotation = respawnPoint.rotation;
    }

    void HP25percent()
    {
        if (healthValue <= maxHealth*0.25)
        {
            fillColor.GetComponent<Image>().color = new Color32(255, 0, 0, 120);
        }
        else if (healthValue <= maxHealth*0.5)
        {
            fillColor.GetComponent<Image>().color = new Color32(250, 159, 159, 150);
        }
        else fillColor.GetComponent<Image>().color = new Color32(226, 226, 226, 120);
    }
}
