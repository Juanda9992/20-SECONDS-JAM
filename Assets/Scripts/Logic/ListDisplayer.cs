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
        Debug.LogFormat("{0}, {1}", objectToShow.Name,objectToShow.value);
        calculator.AddScore(objectToShow.value);
        onObjectReceived?.Invoke(objectToShow,objectToShow.value);
    }

    public void AddPenaltyScore(DamageableObject objectToAdd)
    {
        Debug.LogFormat("Penalty of {0}",objectToAdd.value);
        if(objectToAdd.damageType == DamageableObject.DamageType.fall)
        {
            FallableObject fallableObject = objectToAdd.GetComponent<FallableObject>();
            calculator.AddScore(fallableObject.fallValue);
            onObjectReceived?.Invoke(objectToAdd,fallableObject.fallValue);
        }
        else if(objectToAdd.damageType == DamageableObject.DamageType.push)
        {
            PushableObject pushable = objectToAdd.GetComponent<PushableObject>();
            calculator.AddScore(pushable.pushValue);
            onObjectReceived?.Invoke(objectToAdd,pushable.pushValue);
        }
    }
}
