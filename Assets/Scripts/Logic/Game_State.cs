using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Game_State : MonoBehaviour
{
    public static Game_State Game_State_Instance;

    public enum GameStatus{menu,idle,playing,calculating,finished}

    public GameStatus currentStatus = GameStatus.menu;

    public Action<GameStatus> onStatusChanged;
    // Start is called before the first frame update
    private void Awake()
    {
        if(Game_State_Instance == null)
        {
            Game_State_Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    private void Update()
    {
        if(currentStatus == GameStatus.idle && Input.anyKeyDown)
        {
            currentStatus = GameStatus.playing;
            UpdateStatus(currentStatus);
        }
    }

    public void UpdateStatus(GameStatus status)
    {
        currentStatus= status;
        onStatusChanged?.Invoke(status);
    }
}
