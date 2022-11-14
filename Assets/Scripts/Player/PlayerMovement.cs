using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 15;
    private Rigidbody rb;
    private Vector3 nextMovement;
    private float xAxis,zAxis;
    
    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        nextMovement = Vector3.zero;
    }

    // Update is called once per frame
    private void Update()
    {
        nextMovement.x = Input.GetAxis("Horizontal");
        nextMovement.z = Input.GetAxis("Vertical");
    }
    private void FixedUpdate()
    {
        rb.AddForce(nextMovement * speed, ForceMode.Acceleration);
    }
}
