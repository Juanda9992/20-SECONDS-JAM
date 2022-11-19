using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCalculator : MonoBehaviour
{
    private int currentScore = 0;
    public int GetScore()
    {
        Debug.Log("Your Score is: " + currentScore);
        return currentScore;
    }

    public void AddScore(int scoreToAdd)
    {
        currentScore += scoreToAdd;
    }
}
