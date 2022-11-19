using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TimeScaleChanger : MonoBehaviour
{
    [SerializeField] private float scaleToChange;
    [SerializeField] private float scaleDuration;

    private const int DEFAULT_TIME = 1;

    private void ChangeTimeScale()
    {
        DOTween.To(()=> Time.timeScale, x => Time.timeScale = x,scaleToChange,1);
        Invoke("ResetTimeScale",scaleDuration);
    }

    private void ResetTimeScale()
    {
        DOTween.To(()=> Time.timeScale, x => Time.timeScale = x,DEFAULT_TIME,1);
    }
    private void OnEnable()
    {
        BombTimer.OnTimerOut += ChangeTimeScale;
    }

    private void OnDisable()
    {
        BombTimer.OnTimerOut -= ChangeTimeScale;
    }
}
