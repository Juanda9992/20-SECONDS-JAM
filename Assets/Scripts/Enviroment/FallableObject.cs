using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallableObject : DamageableObject
{
    public bool canTakeDamage = false;
    public int fallValue,pushValue;
    [SerializeField] private float minVelocity;
    private bool damageTaken = false;

    private void Start() 
    {
        damageType = DamageType.fall;    
    }
    private void Update() 
    {
        if(!damageTaken)
        {
            if(rb.angularVelocity.magnitude > minVelocity && !canTakeDamage)
            {
                canTakeDamage = true;
            }
            if(rb.angularVelocity.magnitude == 0 && canTakeDamage)
            {
                damageType = DamageType.fall;
                Displayer.AddPenaltyScore(this);
                damageTaken = true;
            }    
        }
    }

    
    private void OnCollisionEnter(Collision other) 
    {
        if(other.transform.CompareTag("Player"))
        {
            damageType = DamageType.push;
            Displayer.AddPenaltyScore(this);
        }    
    }
    

}
