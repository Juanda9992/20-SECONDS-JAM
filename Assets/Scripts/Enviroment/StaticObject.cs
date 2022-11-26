using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticObject : DamageableObject
{
    public int triggerValue;
    private bool hasTriggered = false;

    private void Start() 
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
    }
    public void Trigger()
    {
        hasTriggered = true;
        Displayer.AddPenaltyScore(this);
        rb.isKinematic = false;
    }

    private void OnCollisionEnter(Collision other) 
    {
        if (other.transform.CompareTag("Player"))
        {
            Trigger();
        }    
    }
}