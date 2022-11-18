using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushableObject : DamageableObject
{
    public int pushValue;

    private void Start() 
    {
        damageType = DamageType.push;    
    }

    private void OnCollisionEnter(Collision other) 
    {
        if(other.transform.CompareTag("Player"))
        {
            Displayer.AddPenaltyScore(this);
            damageType = DamageType.push;
        }    
    }
}
