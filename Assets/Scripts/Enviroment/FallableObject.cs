using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallableObject : DamageableObject
{
    public bool canTakeDamage = false;
    public int fallValue;
    [SerializeField] private float minVelocity;
    private bool damageTaken = false;

    private ListDisplayer displayer;


    private void Start() 
    {
        displayer = GameObject.FindObjectOfType<ListDisplayer>();    
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
                value += fallValue;
                displayer.ShowObjectsDamaged(this);
                damageTaken = true;
            }    
        }
    }
    

}
