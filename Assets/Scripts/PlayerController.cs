using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerController : MonoBehaviour
{
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GlobalHealth.healthValue <= 0)
        {
            player.transform.tag = "Untagged";
            player.GetComponent<FirstPersonController>().enabled = false;
        }
    }
}
