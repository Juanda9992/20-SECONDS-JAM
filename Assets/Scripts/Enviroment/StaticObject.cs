using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticObject : DamageableObject
{
    public int triggerValue;
    private bool hasTriggered = true;
    private float timeBetweenCollisions = 2f;
    private Collider thisCollider;
    private Collider playerCollider;

    private void Start() 
    {
        GetDependences();
        thisCollider = GetComponent<Collider>();
        rb.isKinematic = true;
        Invoke("ResetCollision",1);
    }
    public void Trigger()
    {
        if(!hasTriggered)
        {
            Displayer = GameObject.FindObjectOfType<ListDisplayer>();
            hasTriggered = true;
            Displayer.AddPenaltyScore(this);
            rb.isKinematic = false;
            Invoke("ResetCollision",timeBetweenCollisions);
        }
    }

    private void ResetCollision()
    {
        hasTriggered = false;
        if(playerCollider != null)
        {
            Physics.IgnoreCollision(thisCollider,playerCollider,false);
        }
    }
    private void DisableCollision()
    {
        Physics.IgnoreCollision(thisCollider,playerCollider,true);
        rb.AddForce(Random.insideUnitSphere * Random.Range(6,16),ForceMode.Impulse);
    }
    private void OnCollisionEnter(Collision other) 
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Destructibles") && !hasTriggered)
        {
            Trigger();
            playerCollider = other.collider;
            DisableCollision();

        }    
    }
}