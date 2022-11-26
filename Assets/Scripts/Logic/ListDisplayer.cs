using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ListDisplayer : MonoBehaviour
{
    public static Action<DamageableObject,int> onObjectReceived;
    private ScoreCalculator calculator;
    private void Start()
    {
        calculator = GameObject.FindObjectOfType<ScoreCalculator>();
    }
    public void ShowObjectsDamaged(DamageableObject objectToShow)
    {
        calculator.AddScore(objectToShow.value);
        onObjectReceived?.Invoke(objectToShow,objectToShow.value);
    }

    public void AddPenaltyScore(DamageableObject objectToAdd)
    {
        FallableObject fallableObject = objectToAdd.GetComponent<FallableObject>();
        if(fallableObject != null)
        {
            if(objectToAdd.damageType == DamageableObject.DamageType.fall)
            {
                calculator.AddScore(fallableObject.fallValue);
                onObjectReceived?.Invoke(objectToAdd,fallableObject.fallValue);
            }
            else if(objectToAdd.damageType == DamageableObject.DamageType.push)
            {
                calculator.AddScore(fallableObject.pushValue);
                onObjectReceived?.Invoke(objectToAdd, fallableObject.pushValue);
            }
        }

    }
}
