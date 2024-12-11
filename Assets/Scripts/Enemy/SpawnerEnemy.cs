using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpawnerEnemy : Enemy
{
    [SerializeField] private Weapon weapon;
    [SerializeField] private float shootingRange = 6;
    [SerializeField] private float setbackDistance = 5;

    private float distanceFromPlayer;
    private float angle;
    public static event Action<int> OnPointsEarned;


    protected override void Start()
    {
        base.Start();

        if (gameObject.TryGetComponent(out Weapon _weapon))
        {
            weapon = _weapon;
        }
        else
        {
            Debug.LogWarning("EnemyRangedFire does not have a Weapon component!");
        }
    }

    protected override void Update()
    {
        base.Update();

        EnemyMovement();

        if (distanceFromPlayer <= shootingRange)
        {
            transform.eulerAngles = new Vector3(0, 0, angle);

            weapon.PerformShot();
        }                       
    }

    protected override void EnemyMovement()
    {
        Vector2 direction = player.position - gameObject.transform.position;
        angle = Vector2.SignedAngle(Vector2.right, direction);

        float distanceFromPlayer = Vector2.Distance(transform.position, player.position);

        if (distanceFromPlayer <= setbackDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
        }
    }
    public override void Die()
    {
        base.Die();
        Destroy(gameObject);

    }

    protected override void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, distanceDetection);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, shootingRange);

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, setbackDistance);
    }
}
