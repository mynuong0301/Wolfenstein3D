using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandGunFire : MonoBehaviour
{
    public GameObject theGun;
    public GameObject muzzleFlash;
    public AudioSource gunFire;
    public AudioSource emptyAmmo;
    public bool isFiring = false;
    public GameObject player;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (isFiring == false)
            {
                StartCoroutine(FiringHandgun());
            }

        }
    }

    IEnumerator FiringHandgun()
    {
        GlobalAmmo ammo = player.GetComponent<GlobalAmmo>();
        if (ammo.GunFire())
        {
            isFiring = true;
            theGun.GetComponent<Animator>().SetTrigger("Fire");
            muzzleFlash.SetActive(true);
            gunFire.Play();
            yield return new WaitForSeconds(0.05f);
            muzzleFlash.SetActive(false);
            //yield return new WaitForSeconds(0.25f);
            isFiring = false;
        }
        else
        {
            emptyAmmo.Play();
        }
    }
}
