using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListDisplayer : MonoBehaviour
{
    public void ShowObjectsDamaged(DamageableObject objectToShow)
    {
        Debug.Log(objectToShow.name);
    }
}
