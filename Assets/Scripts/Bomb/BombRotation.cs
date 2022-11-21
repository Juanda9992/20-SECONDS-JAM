using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombRotation : MonoBehaviour
{
    private Transform desiredRotation;
    [SerializeField] private float rotSpeed;
    // Start is called before the first frame update
    void Start()
    {
        desiredRotation = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation,desiredRotation.rotation,rotSpeed * Time.deltaTime);
    }
}
