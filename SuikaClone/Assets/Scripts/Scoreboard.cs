using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Scoreboard : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;

    private void Start() 
    {
        ScoreContainer.Instance.OnScoreChanged += Scoreboard_OnScoreChanged;
        UpdateScore();
    }

    private void Scoreboard_OnScoreChanged(object sender, EventArgs e)
    {
        UpdateScore();
    }
    
    void UpdateScore()
    {
        scoreText.text = ScoreContainer.Instance.Score.ToString();
    }
}
