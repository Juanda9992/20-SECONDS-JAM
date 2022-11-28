using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        Game_State.Game_State_Instance.UpdateStatus(Game_State.GameStatus.idle);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
