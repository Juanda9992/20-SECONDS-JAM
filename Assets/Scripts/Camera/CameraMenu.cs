using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMenu : MonoBehaviour
{
    [SerializeField]private float rotSpeed;
    [SerializeField] private List<Transform> pointsToSpawn = new List<Transform>(); 
    void Start()
    {
        transform.position = pointsToSpawn[Random.Range(0,pointsToSpawn.Count)].position;
        transform.position = new Vector3(transform.position.x,8,transform.position.z);
    }

    private void Update()
    {
        if(Game_State.Game_State_Instance.currentStatus == Game_State.GameStatus.menu)
        {
            transform.Rotate(0,rotSpeed * Time.deltaTime,0,Space.World);
        }    
    }
}
