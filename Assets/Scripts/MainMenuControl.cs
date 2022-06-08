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
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(1);
    }

    private void Update()
    {
        
    }

    void GameInit()
    {
        float movementSpeed = PlayerPrefs.GetFloat("movementSpeed");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
