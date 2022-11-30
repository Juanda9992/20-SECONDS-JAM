using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    public bool isMoving;
    [SerializeField] private float speed = 15;
    private Rigidbody rb;
    private Vector3 nextMovement;
    private float xAxis,zAxis;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        nextMovement = Vector3.zero;
    }

    private void Update()
    {
        zAxis = Input.GetAxis("Vertical");
        isMoving = zAxis != 0;
    }
    private void FixedUpdate()
    {
        if(Game_State.Game_State_Instance.currentStatus == Game_State.GameStatus.playing)
        {
            rb.velocity = transform.forward * zAxis * speed;
        }
    }
}
