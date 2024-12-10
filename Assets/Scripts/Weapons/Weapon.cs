using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected GameObject munition;
    [SerializeField] protected Transform[] firePoints;
    [SerializeField] protected float fireRate;
    protected float lastShot;

    public abstract void PerformShot();
}