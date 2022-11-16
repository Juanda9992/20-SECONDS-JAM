using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListDisplayer : MonoBehaviour
{
    private ScoreCalculator calculator;
    private void Start()
    {
        calculator = GameObject.FindObjectOfType<ScoreCalculator>();
    }
    public void ShowObjectsDamaged(DamageableObject objectToShow)
    {
        Debug.LogFormat("{0}, {1}", objectToShow.Name,objectToShow.value);
        calculator.AddScore(objectToShow.value);
    }
}
