using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BestScoreManager : MonoBehaviour
{
    public int currentScore;
    public int bestcore;
    [SerializeField] private TextMeshProUGUI bestScoreText;

    private void Start()
    {
        bestcore = PlayerPrefs.GetInt("Best Score",0);    
    }

    private void UpdateText()
    {
        bestScoreText.text = "Your Best Score: " + bestcore.ToString();
    }

    public void ReadScore(int scoreToRead)
    {
        if(scoreToRead < bestcore)
        {
            bestcore = scoreToRead;
            PlayerPrefs.SetInt("Best Score",scoreToRead);
        }
        if(PlayerPrefs.GetInt("Best Score",0) <= 10)
        {
            PlayerPrefs.SetInt("Best Score",scoreToRead);
        }
        UpdateText();
    }

}
