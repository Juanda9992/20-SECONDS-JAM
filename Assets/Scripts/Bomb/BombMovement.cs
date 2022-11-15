using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombMovement : MonoBehaviour
{
    [SerializeField] private Transform nextPosition;
    [SerializeField] private float movementSpeed;
    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position,nextPosition.position,movementSpeed);
    }
}
