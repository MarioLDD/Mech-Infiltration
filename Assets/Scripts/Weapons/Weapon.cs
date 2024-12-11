using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected GameObject munition;
    [SerializeField] protected int poolSize;
    [SerializeField] protected Transform[] firePoints;
    [SerializeField] protected float fireRate;
    protected float lastShot;

    void Start()
    {
        ObjectPool.Instance.CreatePool(munition, poolSize);
    }

    public abstract void PerformShot();

    public virtual void DestroyWeapon()
    {
        Destroy(gameObject);
    }
}