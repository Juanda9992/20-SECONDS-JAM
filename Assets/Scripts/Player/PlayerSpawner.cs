using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public SpawnPoint currentPoint;
    [SerializeField] private List<SpawnPoint> spawnPoints = new List<SpawnPoint>();
    private Transform currentTransform;
    
    // Start is called before the first frame update
    private void Awake()
    {
        currentPoint = spawnPoints[Random.Range(0,spawnPoints.Count)];
        currentTransform = currentPoint.spawnTransform;
        transform.position = currentTransform.position;
        transform.rotation = currentTransform.rotation;
    }
}
