using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class EnemyArmy : MonoBehaviour
{
    private Transform player;
    public float speed = 1;
    public float distanceDetection = 8;

    public Rigidbody2D bullet;
    public Transform firePoint;
    public float shootingRange = 6;
    public float retreatDistance = 5;
    private Rigidbody2D proyectileRb;
    public float proyectileForce = 10;
    public float fireRate = 0.5f;
    private float nextFireTime;

    public TMP_Text scoreText;
    public int point=15;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
       
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = player.position - gameObject.transform.position;
        float angle = Vector2.SignedAngle(Vector2.right, direction);
        float distanceFromPlayer = Vector2.Distance(player.position, transform.position);
        if (distanceFromPlayer < distanceDetection && distanceFromPlayer > shootingRange)
        {
            transform.eulerAngles = new Vector3(0, 0, angle);
            transform.position = Vector2.MoveTowards(gameObject.transform.position, player.position, speed * Time.deltaTime);
        }
        else if (distanceFromPlayer <= shootingRange)
        {
            transform.eulerAngles = new Vector3(0, 0, angle);
            if (nextFireTime < Time.time)
            {
                proyectileRb = Instantiate(bullet, firePoint.position, Quaternion.identity);
                proyectileRb.AddRelativeForce(direction.normalized * proyectileForce, ForceMode2D.Impulse);
                nextFireTime = Time.time + fireRate;

            }
            if ( distanceFromPlayer <= retreatDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
            }
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
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(gameObject.transform.position, shootingRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(gameObject.transform.position, retreatDistance);
    }
}
