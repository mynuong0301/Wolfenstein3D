using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerController : MonoBehaviour
{
    public GameObject player; 
    public GameObject hurtFlash;
    int genHurt;
    public AudioSource[] hurtSound;
    public static bool isHadKey = false;

    private void Update()
    {
        if (GlobalHealth.isDead || FloorManager.isComplete)
        {
            player.transform.tag = "Untagged";
            player.GetComponent<FirstPersonController>().enabled = false;
        }
        else
        {
            player.transform.tag = "Player";
            player.GetComponent<FirstPersonController>().enabled = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ammo")
        {
            GlobalHealth.healthValue -= 5;
            genHurt = Random.Range(0, 3);
            hurtSound[genHurt].Play();
            hurtFlash.SetActive(true);
            StartCoroutine(waitForHurtFlashEnd(0.15f));
        }
    }

    IEnumerator waitForHurtFlashEnd(float value)
    {
        yield return new WaitForSeconds(value);
        hurtFlash.SetActive(false);
    }
}
