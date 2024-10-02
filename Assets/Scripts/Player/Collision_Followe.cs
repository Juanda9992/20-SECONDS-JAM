using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision_Followe : MonoBehaviour
{
    [SerializeField] private Transform player;

    void Update()
    {
        transform.position = player.position;        
    }
}
