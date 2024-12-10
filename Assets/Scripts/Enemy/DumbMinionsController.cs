using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DumbMinionsController : MonoBehaviour
{
    private Transform player;
    public float speed = 1;
    public int damage = 1;
    public TMP_Text scoreText;

    public int point = 1;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
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
    /*
    public void Point()
    {
        ScoreManager.score = ScoreManager.score + point;
        scoreText.text = "Score: " + ScoreManager.score.ToString();
    }*/
}
