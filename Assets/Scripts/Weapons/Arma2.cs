using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Arma2 : MonoBehaviour
{
    private Rigidbody2D proyectileRb;

    public Rigidbody2D misilesPrefabs;
    private Transform playerangle;
    public Transform fireposition;
    // Start is called before the first frame update
    void Start()
    {

        playerangle = GameObject.FindGameObjectWithTag("Weapons").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Fire()
    {
        proyectileRb = Instantiate(misilesPrefabs, fireposition.position, playerangle.rotation);
        


    }




}
