using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreCalculatorUI : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private GameObject containerObject;
    private ScoreCalculator calculator;
    private void Start()
    {
        calculator = GameObject.FindObjectOfType<ScoreCalculator>();
    }

    public void ShowPanelUI()
    {
        panel.SetActive(true);
        containerObject.SetActive(false);
        ShowScore();
    }

    private void ShowScore()
    {
        scoreText.text = "Your Damage: " + calculator.GetScore().ToString();
    }

    void ReadGameStatus(Game_State.GameStatus statusToRead)
    {
        if(statusToRead == Game_State.GameStatus.finished)
        {
            ShowPanelUI();
        }
    }


    private void OnEnable()
    {
        Game_State.Game_State_Instance.onStatusChanged += ReadGameStatus;
    }

    void OnDisable()
    {
        Game_State.Game_State_Instance.onStatusChanged -= ReadGameStatus;
    }
}
