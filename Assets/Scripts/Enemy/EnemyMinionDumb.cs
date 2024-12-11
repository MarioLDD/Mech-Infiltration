using System;
using UnityEngine;

public class EnemyMinionDumb : Enemy, IPooledObject
{
    private GameObject originPrefab;
    public GameObject OriginPrefab { set => originPrefab = value; }
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

    protected override void EnemyMovement()
    {
        if (player != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);

    }

    public override void Die()
    {
        base.Die();
        ObjectPool.Instance.ReturnObject(originPrefab, this.gameObject);
    }
}