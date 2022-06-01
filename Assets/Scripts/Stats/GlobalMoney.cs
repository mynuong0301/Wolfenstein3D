using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalMoney : MonoBehaviour
{
    public GameObject moneyDisplay;
    public static int moneyValue;
    public int internalMoney;

    // Start is called before the first frame update
    void Start()
    {
        moneyValue = 0;
    }

    // Update is called once per frame
    void Update()
    {
        internalMoney = moneyValue;
        moneyDisplay.GetComponent<Text>().text = "" + moneyValue;
    }
}
