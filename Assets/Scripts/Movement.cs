using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    bool nothing = false;
    public float speed = 1f;
    public Rigidbody rigidbodygg;

    private void Start()
    {
        rigidbodygg = GetComponent<Rigidbody>();
    }
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            nothing = true;
        }
        if (rigidbodygg.velocity.z < 0)
        {
            rigidbodygg.constraints = RigidbodyConstraints.FreezeAll;
            nothing = false;
        }
    }

    void FixedUpdate()
    {
        if (!nothing)
        {
            rigidbodygg.AddForce(transform.forward * speed);
        }
        
    }

    
}
