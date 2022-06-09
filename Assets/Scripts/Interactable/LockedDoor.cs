using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LockedDoor : Interactable
{
    public GameObject doorTrigger;
    //public AudioSource useKeySound;
    public GameObject keyUI;
    bool isLocked = true;

    public override void OnInteract()
    {
        if (isLocked)
        {
            InteractText = "Press F to open the door";

            displayText.GetComponent<Text>().text = InteractText;
            displayText.SetActive(true);

            if (isPressF && isInteracting)
            {
                isPressF = false;
                //useKeySound.Play();
                DoorOpenFirst.isUsedKey = true;
                keyUI.SetActive(false);
                isInteracting = false;
                isLocked = false;
                displayText.GetComponent<Text>().text = "";
            }
        }
    }
}
