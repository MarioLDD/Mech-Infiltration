using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Misil : MonoBehaviour
{
    public int damage = 2;
    private Rigidbody2D proyectileRb;
    public float proyectileForce = 10;
    public float radioExplision = 5;
    public LayerMask capasObjetos;
    public GameObject particleSistem;

    private GameObject parentObject;

    void Start()
    {
        proyectileRb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 60f);
        /*
        if (transform.parent.gameObject.tag != null)
        {
            if (transform.parent.gameObject.CompareTag("Enemy"))
            {
                parentObject = transform.parent.gameObject;
            }
        }
        */
    }

    // Update is called once per frame
    void Update()
    {
        proyectileRb.AddRelativeForce(Vector2.up * proyectileForce, ForceMode2D.Force);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("Player"))
        {
            // if(parentObject != collision.gameObject)

            Collider2D[] collisionObj = Physics2D.OverlapCircleAll(transform.position, radioExplision, capasObjetos);
            foreach (Collider2D objeto in collisionObj)
            {
                //Debug.Log("Objeto colisionado: " + objeto.gameObject.name);


                if (objeto.gameObject.GetComponent<IHealthSystem>() != null)
                {
                    objeto.gameObject.GetComponent<IHealthSystem>().TakeDamage(damage);
                }


            }
            Instantiate(particleSistem, transform.position, Quaternion.identity);
            Destroy(gameObject);


        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radioExplision);
    }



}
