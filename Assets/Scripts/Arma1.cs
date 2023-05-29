using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arma1 : MonoBehaviour
{
    private Rigidbody2D proyectileRb;
    public Rigidbody2D proyectil1;
    private Transform playerangle;
    public Transform fireposition;
    public float proyectileForce = 10;

    private Transform enemyParent;

    // Start is called before the first frame update
    void Start()
    {

        playerangle = GameObject.FindGameObjectWithTag("Weapons").transform;
        enemyParent = GameObject.FindGameObjectWithTag("EnemyParent").transform;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Fire()
    {
        Debug.Log("laser");
        proyectileRb = Instantiate(proyectil1, fireposition.position, playerangle.rotation);

        proyectileRb.AddRelativeForce(Vector2.up * proyectileForce, ForceMode2D.Impulse);

    }




}
