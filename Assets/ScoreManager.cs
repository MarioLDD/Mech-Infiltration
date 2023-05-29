using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text scoreText;
    public static int score = 0;


    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Score: " + score.ToString();

    }





}
