using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RespawnCountdown : MonoBehaviour
{
    public Text respawnCountdown;
    public int respawnTime = 5;
    public int count;
    public static bool start = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (start)
        {
            start = false;
            count = respawnTime;
            StartCoroutine(CountStart());
        }
    }

    IEnumerator CountStart()
    {
        while (count > 0)
        {
            respawnCountdown.enabled = false;
            respawnCountdown.text = "" + count;
            respawnCountdown.enabled = true;
            count--;
            yield return new WaitForSeconds(0.9f);
        }
        respawnCountdown.enabled = false;
    }
}
