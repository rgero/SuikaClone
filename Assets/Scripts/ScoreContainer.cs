using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreContainer : MonoBehaviour
{
    public static ScoreContainer Instance { get; private set; }
    public int Score {get; private set;}
    public bool isAlive;

    public event EventHandler OnScoreChanged;
    public event EventHandler OnGameEnded;

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
        isAlive = true;
    }

    public void incrementScore(int value)
    {
        Score += value;
        OnScoreChanged?.Invoke(this, EventArgs.Empty);
    }

    public void hasDied()
    {
        isAlive = false;
        OnGameEnded.Invoke(this, EventArgs.Empty);
    }

    internal void endGame()
    {
        PlayerPrefs.SetInt("SuikaScore", Score);
        PlayerPrefs.Save();
        SceneManager.LoadScene("GameOverScene");
    }
}
