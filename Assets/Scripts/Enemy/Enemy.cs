using System;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected float speed = 1;
    [SerializeField] protected int damage = 1;
    [SerializeField] protected int scorePoints = 1;
    [SerializeField] protected float distanceDetection = 0f;

    protected Transform player;
    public static event Action<int> OnPointsEarned;

    protected virtual void Start()
    {
        player = FindObjectOfType<PlayerController>()?.transform;

        if (player == null)
        {
            Debug.LogWarning("The player is not found");
        }

        if(gameObject.TryGetComponent(out HealthSystem healthSystem))
        {
            healthSystem.onHealthZero.AddListener(Die);
        }
        else
        {
            Debug.LogWarning("HealthSystem component not found");
        }
    }

    protected virtual void Update()
    {
        if (player == null)
            return;
    }

    protected virtual void EnemyMovement()
    {
        float distanceFromPlayer = Vector2.Distance(transform.position, player.position);

        if (distanceFromPlayer < distanceDetection)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
    }

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (collision.gameObject.TryGetComponent(out IHealthSystem healthSystem))
            {
                healthSystem.TakeDamage(damage);
            }
            Destroy(gameObject);
        }
    }

    public virtual void Die()
    {
        OnPointsEarned?.Invoke(scorePoints);
    }

    protected virtual void OnDrawGizmosSelected()
    {

    }
}