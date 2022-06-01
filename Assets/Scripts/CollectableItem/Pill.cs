using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pill : Interactable
{
    public GameObject pill;
    public AudioSource collectSound;

    public override void OnInteract()
    {
        InteractText = "Press F to pickup";

        displayText.GetComponent<Text>().text = InteractText;
        displayText.SetActive(true);

        if (isPressF && isInteracting)
        {
            isPressF = false;
            collectSound.Play();
            if (GlobalHealth.healthValue + 10 > 100)
                GlobalHealth.healthValue = 100;
            else GlobalHealth.healthValue += 10;
            isInteracting = false;
            displayText.GetComponent<Text>().text = "";
            pill.GetComponent<BoxCollider>().enabled = false;
            pill.SetActive(false);
        }
    }
}
