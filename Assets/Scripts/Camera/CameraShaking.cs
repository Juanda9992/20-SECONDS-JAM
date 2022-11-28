using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraShaking : MonoBehaviour
{
    private void ShakeCamera()
    {
        transform.DOShakePosition(3);
        transform.DOShakeRotation(3,8,8);
    }

    private void ReadGameStatus(Game_State.GameStatus statusToRead)
    {
        if(statusToRead == Game_State.GameStatus.calculating)
        {
            ShakeCamera();
        }
    }

    private void OnEnable()
    {
        Game_State.Game_State_Instance.onStatusChanged += ReadGameStatus;    
    }

    private void OnDisable() 
    {
        Game_State.Game_State_Instance.onStatusChanged -= ReadGameStatus;    
    }
}
