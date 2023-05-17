using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private Transform player;
    public float speed = 1;
    public float retreatDistance = 8;

    public GameObject bullet;
    public Transform firePoint;
    public float shootingRange = 6;
    private GameObject proyectileRb;
    public float fireRate = 0.5f;
    private float nextFireTime;

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
        if (distanceFromPlayer < retreatDistance)
        {
            //Debug.Log("muy cerca");

            transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
        }
        if (distanceFromPlayer <= shootingRange && nextFireTime < Time.time)
        {
            transform.eulerAngles = new Vector3(0, 0, angle);

            proyectileRb = Instantiate(bullet, transform.position, Quaternion.identity);
            nextFireTime = Time.time + fireRate;

        }


        
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(gameObject.transform.position, retreatDistance);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(gameObject.transform.position, shootingRange);
    }
}
