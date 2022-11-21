using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombTimer : MonoBehaviour
{
    public delegate void onTimerOut();
    public static event onTimerOut OnTimerOut;
    public const float TIME = 20;
    private float currentTime;
    private bool gameStarted = false, hasExploded = false;
    // Start is called before the first frame update
    private void Start()
    {
        currentTime = TIME;
    }

    // Update is called once per frame
    private void Update()
    {
        if(gameStarted && currentTime > 0)
        {
            currentTime -= Time.deltaTime;
        }

        if(currentTime <= 0 && !hasExploded)
        {
            hasExploded = true;
            OnTimerOut?.Invoke();
        }

    }

    private void ReadGameStatus(Game_State.GameStatus currentStatus)
    {
        if(currentStatus == Game_State.GameStatus.playing)
        {
            gameStarted = true;
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
