using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesAI : MonoBehaviour
{
    public string hitTag;
    public bool lookingAtPlayer = false;
    public GameObject theEnemies;
    public AudioSource gunFireSound;
    public bool isFiring = false;
    public float fireRate = 1.5f;
    public GameObject ammoPrefab;
    public Transform firePoint;


    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit))
        {
            hitTag = hit.transform.tag;
        }

        if (hitTag == "Player" && isFiring == false)
        {
            StartCoroutine(EnemyFire());
        }
        if (hitTag != "Player")
        {
            lookingAtPlayer = false;
        }
    }

    IEnumerator EnemyFire()
    {
        isFiring = true;
        //theEnemies.GetComponent<Animator>().Play("demo_combat_shoot", -1, 0);
        theEnemies.GetComponent<Animator>().Play("demo_combat_shoot");
        gunFireSound.Play();
        //Spawn ammo
        GameObject newAmmo = Instantiate(ammoPrefab, firePoint.position, firePoint.rotation);
        newAmmo.GetComponent<AmmoController>().FirePoint = firePoint;
        newAmmo.transform.tag = "Ammo";

        lookingAtPlayer = true;
        yield return new WaitForSeconds(fireRate);
        isFiring = false;
    }
}
