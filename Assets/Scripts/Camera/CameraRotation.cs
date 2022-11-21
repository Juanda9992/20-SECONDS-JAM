using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    [SerializeField]private Transform playerTransform;
    [SerializeField]private float rotSpeed;
    private Vector3 desiredRotation;
    // Start is called before the first frame update
    void Start()
    {
        desiredRotation.z = transform.rotation.eulerAngles.z;
        desiredRotation.x = transform.rotation.eulerAngles.x;
    }

    // Update is called once per frame
    void Update()
    {
        desiredRotation.y = playerTransform.rotation.eulerAngles.y;
        transform.rotation = Quaternion.Slerp(transform.rotation,Quaternion.Euler(desiredRotation),rotSpeed * Time.deltaTime);
    }
}
