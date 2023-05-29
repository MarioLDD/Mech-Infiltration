using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.VersionControl;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMoveController : MonoBehaviour
{
    private Rigidbody2D playerRb;
    public float movespeed = 5f;
    public float maxSpeed = 5f;
    private Vector2 movement;
   // public GameObject proyectil2;

    private Arma1[] proyectile1;
    private Arma2[] proyectile2;


    public float fireRatioAttack1 = 0.1f;
    public float fireRatioAttack2 = 1f;
    private bool attack1Wait;
    private bool attack2Wait;
    void Start()
    {
        transform.localPosition = new Vector3(0, -4.85f, 10);
        playerRb = GetComponent<Rigidbody2D>();
        attack1Wait = false;
        //   movement.z = 0;
    }

    void Update()
    {

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement.Normalize();

        if (Input.GetMouseButton(0) && !attack1Wait)
        {

            StartCoroutine(Attack1());
        }

        if(Input.GetMouseButtonDown(1) && !attack2Wait)
            {
            StartCoroutine(Attack2());
        }

        if(Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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

    IEnumerator Attack1()
    {
        //  

        proyectile1 = GameObject.FindObjectsOfType<Arma1>();

        for (int i = 0; i < proyectile1.Length; i++)
        {
            proyectile1[i].Fire();
        }
        attack1Wait=true;
        yield return new WaitForSecondsRealtime(fireRatioAttack1);
        attack1Wait = false;
       // Debug.Log("attack 1");
    }

    IEnumerator Attack2()
    {

       

        proyectile2 = GameObject.FindObjectsOfType<Arma2>();

        for(int i = 0; i < proyectile2.Length; i++)
        {
            proyectile2[i].Fire();
        }
        attack2Wait = true;
        yield return new WaitForSecondsRealtime(fireRatioAttack2);
        attack2Wait = false;





        //Debug.Log("attack 2");

    }




}
