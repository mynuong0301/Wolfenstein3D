using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandGunPickUp : Interactable
{
    public GameObject handGun;
    public GameObject collectableGun;
    public AudioSource gunPickupSound;
    public GameObject pickUpDisplay;
    public GameObject gunThumpnail;

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.tag == "Player" && !GlobalHealth.isDead)
    //    {
    //        handGun.SetActive(true);
    //        gunThumpnail.SetActive(true);
    //        collectableGun.SetActive(false);
    //        gunPickupSound.Play();
    //        other.GetComponent<GlobalAmmo>().PickupAmmo(5);
    //        pickUpDisplay.SetActive(false);
    //        pickUpDisplay.GetComponent<Text>().text = "Pick up Gun";
    //        pickUpDisplay.SetActive(true);
    //    }
    //}

    public override void OnInteract()
    {

        //InteractText = "Press F to pickup gun";

        displayText.GetComponent<Text>().text = InteractText;
        displayText.SetActive(true);

        if (isPressF && isInteracting)
        {
            isPressF = false;
            gunPickupSound.Play();
            handGun.SetActive(true);
            gunThumpnail.SetActive(true);
            GlobalAmmo.ammoCount += 5;
            collectableGun.SetActive(false);
            isInteracting = false;
            pickUpDisplay.SetActive(false);
            pickUpDisplay.GetComponent<Text>().text = "Pick up gun";
            pickUpDisplay.SetActive(true);
            displayText.GetComponent<Text>().text = "";
        }

    }
}
