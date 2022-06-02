using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenFirst : MonoBehaviour
{
    public GameObject theDoor;
    public AudioSource doorFX;
    public bool isLocked;
    public static bool isUsedKey = false;
    bool isClosed = true;
    Animator doorAnim;

    private void Start()
    {
        doorAnim = theDoor.GetComponent<Animator>();
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
        doorAnim.SetTrigger("Open");
        isClosed = false;
        isUsedKey = false;
    }

    private void OnTriggerExit(Collider other)
    {
        if (!isClosed && other.gameObject.tag == "Player")
        {
            StartCoroutine(CloseDoor());
            doorAnim.SetTrigger("Close");
        }
    }

    IEnumerator CloseDoor()
    {
        yield return new WaitForSeconds(0.05f);
        doorFX.Play();
        isClosed = true;
    }
}
