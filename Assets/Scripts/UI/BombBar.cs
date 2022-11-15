using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BombBar : MonoBehaviour
{
    private void StartShrinkingBar(Game_State.GameStatus status)
    {
        if(status == Game_State.GameStatus.playing)
        {
            transform.DOScale(Vector3.up,19);
        }
    }

    private void OnEnable()
    {
        Game_State.Game_State_Instance.onStatusChanged = StartShrinkingBar;
    }

}
