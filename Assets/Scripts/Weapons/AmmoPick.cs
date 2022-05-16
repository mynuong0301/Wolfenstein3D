using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPick : MonoBehaviour
{
    public GameObject ammoBox;
    public AudioSource ammoPickupSound;

    private IEnumerator OnTriggerEnter(Collider other)
    {
        //ammoBox.SetActive(false);
        this.GetComponent<Animator>().SetTrigger("Open");
        yield return new WaitForSeconds(0.8f);
        ammoPickupSound.Play();
        other.GetComponent<GlobalAmmo>().PickupAmmo(10);
    }

}
