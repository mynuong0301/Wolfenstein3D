using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtralLife : MonoBehaviour
{
    public AudioSource collectSound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            collectSound.Play();
            GlobalLife.lifeValue++;
            this.gameObject.SetActive(false);
        }
    }
}
