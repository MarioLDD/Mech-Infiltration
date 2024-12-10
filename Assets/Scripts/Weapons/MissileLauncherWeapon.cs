using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileLauncherWeapon : Weapon
{
    [SerializeField] private  float detectionRange = 50f;
    [SerializeField] private LayerMask hitLayers;
    [TagSelector] [SerializeField] private string targetSelectorTag;
    public override void PerformShot()
    {
        if (Time.time > fireRate + lastShot)
        {
            foreach (var item in firePoints)
            {
                if(IsEnemyWithinAim(item) != null)
                {
                    GameObject projectile = Instantiate(munition, item.position, item.rotation);

                    Misil misil = projectile.GetComponent<Misil>(); //codigo de seguimiento
                }
                Instantiate(munition, item.position, item.rotation);
            }
            lastShot = Time.time;
        }
    }
    private Transform IsEnemyWithinAim(Transform transform)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, detectionRange, hitLayers);

        if (hit.collider != null)
        {
            if (hit.collider.CompareTag("Enemy"))
            {
                return hit.collider.transform;
            }
        }
        return null;
    }
}