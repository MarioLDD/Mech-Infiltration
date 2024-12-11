using UnityEngine;

public class LaserWeapon : Weapon
{
    [SerializeField] private float projectileForce;

    public override void PerformShot()
    {
        if (Time.time > fireRate + lastShot)
        {
            foreach (var item in firePoints)
            {
                GameObject projectile = ObjectPool.Instance.GetObject(munition, item.position, item.rotation);

                Rigidbody2D projectile_Rb = projectile.GetComponent<Rigidbody2D>();

                Collider2D projectileCollider = projectile.GetComponent<Collider2D>();
                Collider2D weaponCollider = GetComponent<Collider2D>();

                if (weaponCollider != null && projectileCollider != null)
                {
                    Physics2D.IgnoreCollision(projectileCollider, weaponCollider);
                }


                projectile_Rb.AddRelativeForce(Vector2.up * projectileForce, ForceMode2D.Impulse);
            }
            lastShot = Time.time;
        }
    }
}