using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Chest : Interactable
{
    private bool isOpen = false;
    private bool isCollectable = false;
    public GameObject gold;
    public AudioSource collectSound;

    public override void OnInteract()
    {
        InteractText = "Press F ";
        if (!isCollectable)
        {
            InteractText += isOpen ? action2 : action1;
        }
        else if (CollectableObjectNumber > 0)
        {
            InteractText += pickup;
        }
        displayText.GetComponent<Text>().text = InteractText;
        displayText.SetActive(true);

        if (isPressF && isInteracting)
        {
            isPressF = false;
            if (!isCollectable)
            {
                isOpen = !isOpen;
                if (isOpen && CollectableObjectNumber > 0) isCollectable = true;
                GetComponent<Animator>().SetBool("open", isOpen);
            }
            else
            {
                if (gold.CompareTag("Gold_Ignots"))
                {
                    GlobalMoney.moneyValue += 48;
                    GlobalScore.scoreValue += 500;
                }
                else if (gold.CompareTag("Gold_Bar"))
                {
                    GlobalMoney.moneyValue += 1;
                    GlobalScore.scoreValue += 50;
                }
                collectSound.Play();
                FloorManager.treasureCount++;
                gold.SetActive(false);
                CollectableObjectNumber--;
                isCollectable = false;
            }
        }
    }
}
