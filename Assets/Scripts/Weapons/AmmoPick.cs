using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoPick : Interactable
{
    public GameObject ammoBox;
    public AudioSource ammoPickupSound;
    public GameObject pickUpDisplay;

    
    public override void OnInteract()
    {

        InteractText = "Press F to pickup bullet";

        displayText.GetComponent<Text>().text = InteractText;
        displayText.SetActive(true);

        if (isPressF && isInteracting)
        {
            this.GetComponent<Animator>().SetTrigger("Open");
            isPressF = false;
            isInteracting = false;

            displayText.GetComponent<Text>().text = "";
            StartCoroutine(waitForOpen(1f));
            StartCoroutine(waitForPick(2f));
        }
    }

    IEnumerator waitForOpen(float value)
    {
        yield return new WaitForSeconds(value);
        ammoPickupSound.Play();
        GlobalAmmo.ammoCount += 20;
        pickUpDisplay.SetActive(false);
        pickUpDisplay.GetComponent<Text>().text = "Pick up 20 bullets";
        pickUpDisplay.SetActive(true);
    }

    IEnumerator waitForPick(float value)
    {
        yield return new WaitForSeconds(value);
        ammoBox.SetActive(false);
    }
}
