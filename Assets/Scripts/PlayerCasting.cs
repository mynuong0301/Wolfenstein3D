using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCasting : MonoBehaviour
{
    public static float distanceFromTarget;
    public float toTarget;
    public string targetName;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit))
        {
            toTarget = hit.distance;
            distanceFromTarget = toTarget;
            targetName = hit.transform.name;
        }

        //checkTargetKey();
    }

    //void checkTargetKey()
    //{
    //    if (targetName == "KeyTrigger")
    //    {
    //        Key.isTarget = true;
    //    }
    //    else Key.isTarget = false;
    //}
}
