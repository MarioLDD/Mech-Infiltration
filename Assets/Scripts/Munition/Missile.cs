using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour, IPooledObject
{
    [Header("Missile Settings")]
    [SerializeField] private int damage = 2;
    [SerializeField] private float projectileForce = 10f;
    [SerializeField] private float explosionRadius = 5f;
    [SerializeField] private LayerMask targetLayers;
    [SerializeField] private GameObject explosionEffect;

    [Header("Lifetime Settings")]
    [SerializeField] private float lifetime = 60f;

    private Rigidbody2D missile_Rb;
    private Transform target;
    public Transform Target { set =>  target = value; }

    private GameObject originPrefab;
    public GameObject OriginPrefab { set => originPrefab = value; }
    
    private void Awake()
    {
        missile_Rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        Invoke("Explode", lifetime);
    }

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }

    private void FixedUpdate()
    {
        if (target != null)
        {
            TrackTarget();
        }
        else
        {
            MoveForward();
        }
    }

    private void MoveForward()
    {
        missile_Rb.AddRelativeForce(Vector2.up * projectileForce, ForceMode2D.Force);
    }

    private void TrackTarget()
    {
        Vector2 direction = (target.position - transform.position).normalized;
        float rotationAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        missile_Rb.rotation = rotationAngle;
        missile_Rb.AddForce(direction * projectileForce * Time.fixedDeltaTime, ForceMode2D.Force);
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        HandleCollision(collision);
    }

    private void HandleCollision(Collision2D collision)
    {
        if (IsTargetLayer(collision.gameObject))
        {
            Explode();
        }
    }

    private bool IsTargetLayer(GameObject obj)
    {
        return ((1 << obj.layer) & targetLayers) != 0;
    }

    private void Explode()
    {
        Collider2D[] affectedObjects = Physics2D.OverlapCircleAll(transform.position, explosionRadius, targetLayers);
        foreach (Collider2D obj in affectedObjects)
        {
            IHealthSystem healthSystem = obj.GetComponent<IHealthSystem>();
            if (healthSystem != null)
            {
                healthSystem.TakeDamage(damage);
            }
        }

        if (explosionEffect != null)
        {
            Instantiate(explosionEffect, transform.position, Quaternion.identity);
        }

        ObjectPool.Instance.ReturnObject(originPrefab, this.gameObject);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}