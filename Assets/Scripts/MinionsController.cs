using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MinionsController : MonoBehaviour
{
    private Transform player;
    public float speed = 1;
    public float distanceDetection = 2;
    public int damage = 1;
    public TMP_Text scoreText;

    public int point = 3;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        float distanceFromPlayer = Vector2.Distance(player.position, gameObject.transform.position);
        if( distanceFromPlayer < distanceDetection)
        transform.position = Vector2.MoveTowards(gameObject.transform.position, player.position, speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (collision.gameObject.GetComponent<IHealthSystem>() != null)
            {
                collision.gameObject.GetComponent<IHealthSystem>().TakeDamage(damage);
            }
            Destroy(gameObject);
        }
    }

    public void Point()
    {
        ScoreManager.score = ScoreManager.score + point;
        scoreText.text = "Score: " + ScoreManager.score.ToString();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(gameObject.transform.position, distanceDetection);
    }
}
