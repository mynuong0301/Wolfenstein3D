using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
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
    public static int myLevel = 1;
    public Button nextBtn;
    public GameObject levelDisplay;
    public GameObject levelCompleteDisplay;

    private void Start()
    {
        myLevel = PlayerPrefs.GetInt("Level");
        levelDisplay.GetComponent<Text>().text = "" + myLevel;
        levelCompleteDisplay.GetComponent<Text>().text = "LEVEL " + myLevel;
    }

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
            nextBtn.Select();
            completePanel.SetActive(true);
            isComplete = true;
            this.gameObject.GetComponent<BoxCollider>().enabled = false;
            myLevel++;
            PlayerPrefs.SetInt("Level", myLevel);
        }
    }

    public void NextLevel()
    {
        Debug.Log("next");
        SceneManager.LoadScene(myLevel);
    }

    public void BackMenu()
    {
        SceneManager.LoadScene(0);
    }
}
