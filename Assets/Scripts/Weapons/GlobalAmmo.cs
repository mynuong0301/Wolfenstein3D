using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalAmmo : MonoBehaviour
{
    public static int ammoCount;
    public GameObject ammoDisplay;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        AmmoDisplay();
    }

    public void PickupAmmo(int value)
    {
        ammoCount += value;
        AmmoDisplay();
    }

    void AmmoDisplay()
    {
        ammoDisplay.GetComponent<Text>().text = "" + ammoCount;
    }

    public bool GunFire()
    {
        if (ammoCount <= 0)
        {
            return false;
        }
        ammoCount -= 1;
        return true;
    }
}
