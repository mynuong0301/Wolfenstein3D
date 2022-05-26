using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoController : MonoBehaviour
{
    public float speed = 2000f;
    public float destroyAfter = 15f; //destroy ammo after 5s

    public Transform FirePoint { get; set; }
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(FirePoint.forward * speed);
    }

    private void Update()
    {
        
        Destroy(gameObject, destroyAfter);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }

}
