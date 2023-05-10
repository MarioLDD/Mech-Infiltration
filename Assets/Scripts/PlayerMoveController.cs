using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.VersionControl;
using UnityEngine;

public class PlayerMoveController : MonoBehaviour
{
    private Rigidbody2D playerRb;
    public float movespeed = 5f;
    public float maxSpeed = 5f;
    private Vector2 movement;
    public GameObject proyectil2;

    private Arma1[] proyectile1;
    private Arma2[] proyectile2;

    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        //   movement.z = 0;
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement.Normalize();

        if (Input.GetMouseButtonDown(0))
        {
            Attack1();
        }

        if(Input.GetMouseButtonDown(1))
            {
            Attack2();
        }



    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (movement.magnitude == 0f)
        {
            playerRb.velocity = Vector2.zero;
        }
        else if (playerRb.velocity.magnitude > maxSpeed)
        {
            playerRb.velocity = playerRb.velocity.normalized * maxSpeed;
        }
        else
        {
            playerRb.AddRelativeForce(movement * movespeed, ForceMode2D.Impulse);
        }
    }

    private void Attack1()
    {
        //  

        proyectile1 = GameObject.FindObjectsOfType<Arma1>();

        for (int i = 0; i < proyectile1.Length; i++)
        {
            proyectile1[i].Fire();
        }
        Debug.Log("attack 1");
    }

    private void Attack2()
    {

       

        proyectile2 = GameObject.FindObjectsOfType<Arma2>();

        for(int i = 0; i < proyectile2.Length; i++)
        {
            proyectile2[i].Fire();
        }






        Debug.Log("attack 2");

    }




}
