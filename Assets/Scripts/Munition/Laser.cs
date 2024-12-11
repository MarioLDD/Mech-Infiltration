using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour, IPooledObject
{
    [SerializeField] private int damage = 1;
    [SerializeField] private GameObject laser_ParticleSystem;
    [StringInList("Player", "Enemy")][SerializeField] private string target;

    private GameObject originPrefab;
    public GameObject OriginPrefab { set => originPrefab = value; }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(target))
        {
            if (collision.gameObject.TryGetComponent(out IHealthSystem iHealthSystem))
            {
                iHealthSystem.TakeDamage(damage);
                BulletImpact();
            }
        }
        BulletImpact();
    }

    private void BulletImpact()
    {
        Instantiate(laser_ParticleSystem, transform.position, Quaternion.identity);
        ObjectPool.Instance.ReturnObject(originPrefab, this.gameObject);
    }
}
