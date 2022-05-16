using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HandGunPickUp : MonoBehaviour
{
    public GameObject handGun;
    public GameObject collectableGun;
    public AudioSource gunPickupSound;

    private void OnTriggerEnter(Collider other)
    {
        handGun.SetActive(true);
        collectableGun.SetActive(false);
        gunPickupSound.Play();
        other.GetComponent<GlobalAmmo>().PickupAmmo(5);
    }

}
