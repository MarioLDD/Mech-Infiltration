using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileLauncherWeapon : Weapon
{
    [SerializeField] private  float detectionRange = 50f;
    [SerializeField] private LayerMask hitLayers;
    [StringInList("Player", "Enemy")][SerializeField] private string targetSelectorTag;
    public override void PerformShot()
    {
        if (Time.time > fireRate + lastShot)
        {
            foreach (var item in firePoints)
            {
                if(IsEnemyWithinAim(item) != null)
                {
                    GameObject projectile = ObjectPool.Instance.GetObject(munition, item.position, item.rotation);


                    Missile misil = projectile.GetComponent<Missile>(); //codigo de seguimiento
                }

                ObjectPool.Instance.GetObject(munition, item.position, item.rotation);
            }
            lastShot = Time.time;
        }
    }
    private Transform IsEnemyWithinAim(Transform transform)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, detectionRange, hitLayers);

        if (hit.collider != null)
        {
            if (hit.collider.CompareTag(targetSelectorTag))
            {
                return hit.collider.transform;
            }
        }
        return null;
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;

        foreach (var firePoint in firePoints)
        {
            Gizmos.DrawLine(firePoint.position, firePoint.position + firePoint.up * detectionRange);
        }
    }



}