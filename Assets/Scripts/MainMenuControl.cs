using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;

public class MainMenuControl : MonoBehaviour
{
    public AudioSource clickSound;
    public GameObject fadeOut;
    public GameObject loading;

    //MainMenu
    public void NewGame()
    {
        GameInit();
        StartCoroutine(NewGameRoutine());
    }

    IEnumerator NewGameRoutine()
    {
        clickSound.Play();
        fadeOut.SetActive(true);
        loading.SetActive(true);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(1);
    }

    public void Continue()
    {
        clickSound.Play();
        fadeOut.SetActive(true);
        loading.SetActive(true);
        SceneManager.LoadScene(FloorManager.myLevel);
    }

    private void Update()
    {
        
    }

    void GameInit()
    {
        float movementSpeed = PlayerPrefs.GetFloat("movementSpeed");
        PlayerPrefs.SetInt("Money", 0);
        FloorManager.myLevel = 1;
        PlayerPrefs.SetInt("Level", FloorManager.myLevel);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
