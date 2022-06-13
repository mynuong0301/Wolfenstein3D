using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenFirst : MonoBehaviour
{
    public GameObject theDoor;
    public AudioSource doorFX;
    public bool isLocked;
    public bool isUsedKey;
    bool isClosed = true;

    private void Start()
    {
        isUsedKey = false;
    }

    private void Update()
    {
        if (isUsedKey)
        {
            isLocked = false;
            OpenDoor();
        }
    }


    void OnTriggerEnter(Collider other)
    {
        if (isClosed && !isLocked && other.gameObject.tag == "Player")
        {
            OpenDoor();
        }
    }

    void OpenDoor()
    {
        doorFX.Play();
        theDoor.GetComponent<Animator>().SetTrigger("Open");
        isClosed = false;
        isUsedKey = false;
    }

    private void OnTriggerExit(Collider other)
    {
        if (!isClosed && other.gameObject.tag == "Player")
        {
            StartCoroutine(CloseDoor());
            theDoor.GetComponent<Animator>().SetTrigger("Close");
        }
    }

    IEnumerator CloseDoor()
    {
        yield return new WaitForSeconds(0.05f);
        doorFX.Play();
        isClosed = true;
    }
}
