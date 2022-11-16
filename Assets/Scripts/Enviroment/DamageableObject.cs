using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageableObject : MonoBehaviour
{
    public Rigidbody rb;
    public string Name;
    public int value;
    protected ListDisplayer Displayer;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        Displayer = GameObject.FindObjectOfType<ListDisplayer>();
    }
}
