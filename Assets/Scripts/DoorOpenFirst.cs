using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenFirst : MonoBehaviour
{
    public GameObject theDoor;
    public AudioSource doorFX;
    bool isClosed = true;
    Animator doorAnim;

    private void Start()
    {
        doorAnim = theDoor.GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (isClosed && other.gameObject.tag == "Player")
        {
            doorFX.Play();
            doorAnim.SetTrigger("Open");
            isClosed = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(CloseDoor());
            doorAnim.SetTrigger("Close");
        }
    }

    IEnumerator CloseDoor()
    {
        yield return new WaitForSeconds(0.2f);
        doorFX.Play();
        isClosed = true;
    }
}
