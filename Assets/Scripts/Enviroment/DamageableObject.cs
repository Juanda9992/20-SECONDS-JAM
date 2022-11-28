using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageableObject : MonoBehaviour
{
    public Rigidbody rb;
    public string Name;
    public int value;
    public enum DamageType {explosion,fall,push,collision};
    public DamageType damageType;
    protected ListDisplayer Displayer;
    private void Awake()
    {
        GetDependences();
    }

    public virtual void GetDependences()
    {
        rb = GetComponent<Rigidbody>();
        Displayer = GameObject.FindObjectOfType<ListDisplayer>();
    }
}
