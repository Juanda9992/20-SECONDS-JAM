using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform desiredPos;
    [SerializeField] private float moveSpeed;
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position,desiredPos.position,moveSpeed * Time.deltaTime);
    }
}