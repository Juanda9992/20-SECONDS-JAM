using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class BombBar : MonoBehaviour
{
    private void StartShrinkingBar(Game_State.GameStatus status)
    {
        if(status == Game_State.GameStatus.playing)
        {
            transform.DOScale(Vector3.up,20).SetEase(Ease.Unset);
        }
    }

    private void OnEnable()
    {
        Game_State.Game_State_Instance.onStatusChanged += StartShrinkingBar;
    }

    private void OnDisable()
    {
        Game_State.Game_State_Instance.onStatusChanged -= StartShrinkingBar;
    }

}



