using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Key : Interactable
{
    //public static bool isTarget = false;
    public GameObject key;
    public GameObject keyUI;
    public AudioSource collectSound;
    public GameObject pickUpDisplay;

    public override void OnInteract()
    {

        InteractText = "Press F to pickup key";

        displayText.GetComponent<Text>().text = InteractText;
        displayText.SetActive(true);

        if (isPressF && isInteracting)
        {
            isPressF = false;
            collectSound.Play();
            keyUI.SetActive(true);
            isInteracting = false;
            pickUpDisplay.SetActive(false);
            pickUpDisplay.GetComponent<Text>().text = "Pick up key";
            pickUpDisplay.SetActive(true);
            displayText.GetComponent<Text>().text = "";
            key.SetActive(false);
        }

    }
}
