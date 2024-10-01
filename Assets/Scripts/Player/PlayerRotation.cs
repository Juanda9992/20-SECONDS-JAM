using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerRotation : MonoBehaviour
{
    [SerializeField] private InputActionReference rotationAction;
    [SerializeField]private float rotSpeed;
    [SerializeField] private float minMagnitude;
    private Vector3 nextRotation;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        nextRotation = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        nextRotation.y = rotationAction.action.ReadValue<float>();
        if(rb.velocity.magnitude > minMagnitude)
        {
            transform.Rotate(nextRotation * rotSpeed * Time.deltaTime);
        }
    }
}
