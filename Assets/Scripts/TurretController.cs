using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    private Transform player;

    public float maxTurnSpeed = 90;
    public float smoothTime = 0.3f;
    private float angle = 90;
    float currentVelocity;
    public float range = 20;
    private float nextFireTime;
    private Rigidbody2D proyectileRb;
    public Rigidbody2D bullet;
    public Transform firePoint;
    public float proyectileForce = 10;
    public float fireRate = 0.5f;
    public LayerMask layerToTarget;

    private Transform enemyParent;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        enemyParent = GameObject.FindGameObjectWithTag("EnemyParent").transform;

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        float targetAngle = Vector2.SignedAngle(Vector3.up, direction);
        angle = Mathf.SmoothDampAngle(angle, targetAngle, ref currentVelocity, smoothTime, maxTurnSpeed);

        transform.eulerAngles = new Vector3(0, 0, angle);

        RaycastHit2D rayInfo = Physics2D.Raycast(transform.position, direction, range, layerToTarget);
        Debug.DrawRay(transform.position, direction * range, Color.green);
        if (rayInfo)
        {
            if (rayInfo.collider.gameObject.CompareTag("Player"))
            {
                if (nextFireTime < Time.time)
                {
                    proyectileRb = Instantiate(bullet, firePoint.position, Quaternion.identity);
                    proyectileRb.transform.SetParent(enemyParent);
                    proyectileRb.AddRelativeForce(direction.normalized * proyectileForce, ForceMode2D.Impulse);
                    nextFireTime = Time.time + fireRate;

                }


            }



        }



    }



    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(gameObject.transform.position, range);
    }
}
