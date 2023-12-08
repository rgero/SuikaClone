using System;
using UnityEngine;

public class ScoreContainer : MonoBehaviour
{
    public static ScoreContainer Instance { get; private set; }
    public int Score {get; private set;} 

    public event EventHandler OnScoreChanged;

    void Start()
    {
        if (Instance != null)
        {
            Debug.LogError("There's more than one ScoreContainer! " + transform + " - " + Instance);
            Destroy(gameObject);
            return;
        }
        Instance = this;
        Score = 0;
    }

    public void incrementScore(int value)
    {
        Score += value;
        OnScoreChanged?.Invoke(this, EventArgs.Empty);
    }
}
