using UnityEngine;
using TMPro;
using System;

public class GameOverScore : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        int totalScore = PlayerPrefs.GetInt("SuikaScore");
        scoreText.text = String.Format("You got {0} points", totalScore);
    }
}
