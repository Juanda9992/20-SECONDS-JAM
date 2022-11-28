using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticObject : DamageableObject
{
    public int triggerValue;
    private bool hasTriggered = false;
    private float timeBetweenCollisions = 2f;
    private Collider thisCollider;
    private Collider playerCollider;

    private void Start() 
    {
        GetDependences();
        thisCollider = GetComponent<Collider>();
        rb.isKinematic = true;
    }
    public void Trigger()
    {
        if(!hasTriggered)
        {
            Displayer = GameObject.FindObjectOfType<ListDisplayer>();
            hasTriggered = true;
            Displayer.AddPenaltyScore(this);
            rb.isKinematic = false;
            if(playerCollider != null)
            {
                Invoke("ResetCollision",timeBetweenCollisions);
            }
        }
    }

    private void ResetCollision()
    {
        hasTriggered = false;
        Physics.IgnoreCollision(thisCollider,playerCollider,false);
    }
    private void DisableCollision()
    {
        Physics.IgnoreCollision(thisCollider,playerCollider,true);
        rb.AddForce(Random.insideUnitSphere * Random.Range(6,16),ForceMode.Impulse);
    }
    private void OnCollisionEnter(Collision other) 
    {
        if (other.transform.CompareTag("Player"))
        {
            Trigger();
            playerCollider = other.collider;
            DisableCollision();

        }    
    }
}