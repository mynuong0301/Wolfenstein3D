using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirstAidKit : Interactable
{
    public GameObject firstAidKit;
    public AudioSource collectSound;

    public override void OnInteract()
    {
        InteractText = "Press F to use first aid kit";

        displayText.GetComponent<Text>().text = InteractText;
        displayText.SetActive(true);

        if (isPressF && isInteracting)
        {
            isPressF = false;
            collectSound.Play();
            GlobalHealth.healthValue = 100;
            isInteracting = false;
            displayText.GetComponent<Text>().text = "";
            firstAidKit.GetComponent<BoxCollider>().enabled = false;
            firstAidKit.SetActive(false);
        }
    }
}
