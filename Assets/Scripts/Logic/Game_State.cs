using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.InputSystem;

public class Game_State : MonoBehaviour
{
    [SerializeField] private InputActionReference startAction;
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
        if(currentStatus == GameStatus.idle && startAction.action.WasPerformedThisFrame())
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
