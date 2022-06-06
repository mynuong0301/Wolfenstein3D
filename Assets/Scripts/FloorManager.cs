using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class FloorManager : MonoBehaviour
{
    public GameObject thePlayer;
    public GameObject completePanel;
    public GameObject enemyDisplay;
    public GameObject treasureDisplay;
    public GameObject scoreDisplay;
    public static int enemyCount = 0;
    public static int treasureCount = 0;
    public static bool isComplete = false;

    private void Update()
    {
        enemyDisplay.GetComponent<Text>().text = "" + enemyCount;
        treasureDisplay.GetComponent<Text>().text = "" + treasureCount;
        scoreDisplay.GetComponent<Text>().text = "" + GlobalScore.scoreValue;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isComplete = true;
            completePanel.SetActive(true);
            this.gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }
}
