using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SoundPitcher : MonoBehaviour
{
    [SerializeField] private float endValue,timeToPitch,delay;
    private AudioSource source;

    private void Start() 
    {
        source = GetComponent<AudioSource>();    
    }

    private void StartPitching()
    {
        source.DOPitch(endValue,timeToPitch).SetDelay(delay);
    }
    private void StopMusic()
    {
        source.volume = 0;
    }

    private void ReadGameStatus(Game_State.GameStatus statusToRead)
    {
        if(statusToRead == Game_State.GameStatus.playing)
        {
            StartPitching();
        }
        else if(statusToRead == Game_State.GameStatus.calculating)
        {
            StopMusic();
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
