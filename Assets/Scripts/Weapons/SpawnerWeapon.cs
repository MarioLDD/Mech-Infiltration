using UnityEngine;

public class SpawnerWeapon : Weapon
{
    public override void PerformShot()
    {
        if (Time.time > fireRate + lastShot)
        {
            foreach (var item in firePoints)
            {
                GameObject projectile = ObjectPool.Instance.GetObject(munition, item.position, item.rotation);

            }
            lastShot = Time.time;
        }
    }
}