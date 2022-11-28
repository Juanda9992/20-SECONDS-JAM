using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public Transform spawnTransform;
    public string spawnPointName;

    private void Awake() 
    {
        spawnTransform = transform;    
    }
}
