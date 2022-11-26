using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticObject : DamageableObject
{
    public int triggerValue;

    private void Start() 
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
    }
    public void Trigger()
    {
        Debug.Log("Triggered");
        rb.isKinematic = false;
    }
}