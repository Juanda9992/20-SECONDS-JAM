using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCalculator : MonoBehaviour
{
    private int currentScore = 0;
    public void ShowScore()
    {
        Debug.Log("Your Score is: " + currentScore);
    }

    public void AddScore(int scoreToAdd)
    {
        currentScore += scoreToAdd;
    }
}
