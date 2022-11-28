using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCalculator : MonoBehaviour
{
    private int currentScore = 0;
    private BestScoreManager manager;
    public int GetScore()
    {
        manager = GameObject.FindObjectOfType<BestScoreManager>();
        Debug.Log("Your Score is: " + currentScore);
        manager.ReadScore(currentScore);
        return currentScore;
    }

    public void AddScore(int scoreToAdd)
    {
        currentScore += scoreToAdd;
    }
}
