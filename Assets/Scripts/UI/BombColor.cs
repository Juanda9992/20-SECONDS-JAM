using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class BombColor : MonoBehaviour
{
    [SerializeField] private Image barImage;

    private void Start() 
    {
        barImage = GetComponent<Image>();
    }

    private void ChangeColor()
    {
        barImage.DOColor(Color.red,20);
    }
    private void ReadGameStatus(Game_State.GameStatus statusToRead)
    {
        if(statusToRead == Game_State.GameStatus.calculating)
        {
            ChangeColor();
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
