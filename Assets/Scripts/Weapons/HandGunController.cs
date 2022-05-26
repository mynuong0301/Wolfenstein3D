using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandGunController : MonoBehaviour
{
    public GameObject theGun;
    public GameObject muzzleFlash;
    public AudioSource gunFire;
    public AudioSource emptyAmmo;
    public bool isFiring = false;
    public GameObject player;
    public GameObject ammoPrefab;
    public Transform firePoint;

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && !GlobalHealth.isDead)
        {
            if (isFiring == false)
            {
                Firing();
            }

        }
    }

    void Firing()
    {
        GlobalAmmo ammo = player.GetComponent<GlobalAmmo>();
        if (ammo.isAmmoExist())
        {
            isFiring = true;
            theGun.GetComponent<Animator>().SetTrigger("Fire");
            muzzleFlash.SetActive(true);
            gunFire.Play();
            //Spawn ammo
            GameObject newAmmo = Instantiate(ammoPrefab, firePoint.position, firePoint.rotation);
            newAmmo.GetComponent<AmmoController>().FirePoint = firePoint;

            StartCoroutine(waitForMuzzleFlashEnd(0.05f));
            isFiring = false;
        }
        else
        {
            emptyAmmo.Play();
        }
    }

    IEnumerator waitForMuzzleFlashEnd(float value)
    {
        yield return new WaitForSeconds(value);
        muzzleFlash.SetActive(false);
    }
}
