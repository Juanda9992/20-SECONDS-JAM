using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Game_State : MonoBehaviour
{
    public static Game_State Game_State_Instance;

    public enum GameStatus{idle,playing,calculating,finished}

    public GameStatus status = GameStatus.idle;

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
        if(status == GameStatus.idle && Input.anyKeyDown)
        {
            status = GameStatus.playing;
            onStatusChanged?.Invoke(status);
        }
    }
}
