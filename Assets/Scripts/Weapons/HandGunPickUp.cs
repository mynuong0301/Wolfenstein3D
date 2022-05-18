using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandGunPickUp : MonoBehaviour
{
    public GameObject handGun;
    public GameObject collectableGun;
    public AudioSource gunPickupSound;
    public GameObject pickUpDisplay;

    private void OnTriggerEnter(Collider other)
    {
        handGun.SetActive(true);
        collectableGun.SetActive(false);
        gunPickupSound.Play();
        other.GetComponent<GlobalAmmo>().PickupAmmo(5);
        pickUpDisplay.SetActive(false);
        pickUpDisplay.GetComponent<Text>().text = "Pick up Gun";
        pickUpDisplay.SetActive(true);
    }

}
