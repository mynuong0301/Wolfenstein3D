using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SettingManager : MonoBehaviour
{
    [Header("Gameplay")]
    public Slider movementSpeed;
    public Slider mouseSensitivity;

    [Header("Video")]
    public Slider quality;

    [Header("Audio")]
    public Slider masterS;
    public Slider musicS;
    public Slider sfxS;
    public AudioMixer masterMixer;
    public AudioMixer musicMixer;
    public AudioMixer sfxMixer;

    // Start is called before the first frame update
    void Start()
    {
        int p_isFirstTime = PlayerPrefs.GetInt("isFirstTime");
        if (p_isFirstTime == 0)
        {
            PlayerPrefs.SetInt("Level", 1);
            PlayerPrefs.SetInt("isFirstTime", 1);
            PlayerPrefs.SetFloat("movementSpeed", 5);
            PlayerPrefs.SetFloat("mouseSensitivity", 2);
            PlayerPrefs.SetFloat("qualityIndex", QualitySettings.GetQualityLevel());
            float master, music, sfx;
            masterMixer.GetFloat("masterVolumn", out master);
            masterS.value = master;
            musicMixer.GetFloat("musicVolumn", out music);
            masterS.value = music;
            sfxMixer.GetFloat("sfxVolumn", out sfx);
            sfxS.value = sfx;
        }
        
        movementSpeed.value = PlayerPrefs.GetFloat("movementSpeed");
        mouseSensitivity.value = PlayerPrefs.GetFloat("mouseSensitivity");

        quality.value = PlayerPrefs.GetFloat("qualityIndex");

        musicS.value = PlayerPrefs.GetFloat("musicVolumn");
        sfxS.value = PlayerPrefs.GetFloat("sfxVolumn");
    }

    //Gameplay
    public void GetMovementSpeed()
    {
        PlayerPrefs.SetFloat("movementSpeed", movementSpeed.value);
    }

    public void GetMouseSensitivity()
    {
        PlayerPrefs.SetFloat("mouseSensitivity", mouseSensitivity.value);
    }

    //Video
    public void SetQuality(float qualityIndex)
    {
        QualitySettings.SetQualityLevel((int)qualityIndex);
        PlayerPrefs.SetFloat("qualityIndex", qualityIndex);
    }

    //Audio
    public void SetMasterVolumn(float volumn)
    {
        //masterMixer.SetFloat("masterVolumn", volumn);
        PlayerPrefs.SetFloat("masterVolumn", volumn);
    }

    public void SetMusicVolumn(float volumn)
    {
        musicMixer.SetFloat("musicVolumn", volumn);
        PlayerPrefs.SetFloat("musicrVolumn", volumn);
    }

    public void SetSFXVolumn(float volumn)
    {
        sfxMixer.SetFloat("sfxVolumn", volumn);
        PlayerPrefs.SetFloat("sfxVolumn", volumn);
    }
}
