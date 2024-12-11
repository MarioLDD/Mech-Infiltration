using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyMinion : Enemy
{
    public static event Action<int> OnPointsEarned;

    protected override void Start()
    {
        base.Start();
    }


    protected override void Update()
    {
        base.Update();

        EnemyMovement();
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);
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
    }
}
