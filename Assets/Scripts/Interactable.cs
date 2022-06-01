using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(BoxCollider))]
public abstract class Interactable : MonoBehaviour
{
    public GameObject displayText;
    public bool isPressF = false;
    public bool isInteracting = false;
    public string InteractText = "Press F to pickup the item";
    [Header("Action")]
    public string action1 = "to open";
    public string action2 = "to close";
    public string pickup = "to pickup gold";
    public int CollectableObjectNumber = 1;

    private void Awake()
    {
        GetComponent<BoxCollider>().isTrigger = true;
        displayText = GameObject.FindGameObjectWithTag("InteractDisplay");
        displayText.GetComponent<Text>().text = "";
    }

    private void Update()
    {
        if (isInteracting)
        {
            OnInteract();
            if (Input.GetButtonDown("Interact"))
            {
                isPressF = true;
            }
        }
    }

    public virtual void OnInteract()
    {

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInteracting = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInteracting = false;
            displayText.SetActive(false);
        }
    }
}
