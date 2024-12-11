using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    private int score = 0;
    void Start()
    {
        scoreText.text = score.ToString();
    }

    private void OnEnable()
    {
        Enemy.OnPointsEarned += UpdateScore;
    }

    private void OnDisable()
    {
        Enemy.OnPointsEarned -= UpdateScore;
    }

    private void UpdateScore(int value)
    {
        score += value;
        scoreText.text = score.ToString();
    }
}