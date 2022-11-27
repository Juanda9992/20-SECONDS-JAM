using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticObject : DamageableObject
{
    public int triggerValue;
    private bool hasTriggered = false;
    private float timeBetweenCollisions = 2f;

    private void Start() 
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
    }
    public void Trigger()
    {
        if(!hasTriggered)
        {
            hasTriggered = true;
            Displayer.AddPenaltyScore(this);
            rb.isKinematic = false;
            rb.AddForce(Random.insideUnitSphere * Random.Range(0,10),ForceMode.Impulse);
            Invoke("ResetCollision",timeBetweenCollisions);
        }
    }

    private void ResetCollision()
    {
        hasTriggered = false;
    }
    private void OnCollisionEnter(Collision other) 
    {
        if (other.transform.CompareTag("Player"))
        {
            Trigger();
        }    
    }
}