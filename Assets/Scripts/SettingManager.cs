using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingManager : MonoBehaviour
{
    [Header("Gameplay")]
    public Slider movementSpeed;
    public Slider mouseSensitivity;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
