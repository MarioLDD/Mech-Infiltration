using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class BossController : MonoBehaviour
{
    private Transform player;

    public float maxTurnSpeed = 90;
    public float smoothTime = 0.3f;
   private float angle = 180;
    float currentVelocity;

    public TMP_Text scoreText;
    public int point = 500;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = player.position - transform.position;

        float targetAngle = Vector2.SignedAngle(Vector2.right, direction);
        angle = Mathf.SmoothDampAngle(angle, targetAngle, ref currentVelocity, smoothTime, maxTurnSpeed);
        transform.eulerAngles = new Vector3(0, 0, angle);
        
    }

    public void Point()
    {
        ScoreManager.score = ScoreManager.score + point;
        scoreText.text = "Score: " + ScoreManager.score.ToString();
    }


}

