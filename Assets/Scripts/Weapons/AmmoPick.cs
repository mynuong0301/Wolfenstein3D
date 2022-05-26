using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoPick : MonoBehaviour
{
    public GameObject ammoBox;
    public AudioSource ammoPickupSound;
    public GameObject pickUpDisplay;

    private IEnumerator OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player" && !GlobalHealth.isDead)
        {
            this.GetComponent<Animator>().SetTrigger("Open");
            yield return new WaitForSeconds(0.8f);
            ammoPickupSound.Play();
            other.GetComponent<GlobalAmmo>().PickupAmmo(10);
            pickUpDisplay.SetActive(false);
            pickUpDisplay.GetComponent<Text>().text = "Pick up 10 bullets";
            pickUpDisplay.SetActive(true);
        }
    }

}
