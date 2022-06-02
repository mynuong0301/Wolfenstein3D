using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretRoomTrigger : MonoBehaviour
{
    public GameObject moveableWall;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            moveableWall.GetComponent<Animator>().SetTrigger("move");
            this.gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }
}
