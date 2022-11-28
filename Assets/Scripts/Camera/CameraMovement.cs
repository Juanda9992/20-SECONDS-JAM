using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform desiredPos;
    [SerializeField] private float moveSpeed;
    void Update()
    {
        if(Game_State.Game_State_Instance.currentStatus == Game_State.GameStatus.playing || Game_State.Game_State_Instance.currentStatus == Game_State.GameStatus.idle)
        {
            transform.position = Vector3.Lerp(transform.position,desiredPos.position,moveSpeed * Time.deltaTime);
        }
    }
}
