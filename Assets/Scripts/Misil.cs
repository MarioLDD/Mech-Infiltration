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
    // Start is called before the first frame update
    void Start()
    {
        proyectileRb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 60f);
    }

    // Update is called once per frame
    void Update()
    {
        proyectileRb.AddRelativeForce(Vector2.up * proyectileForce, ForceMode2D.Force);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Collider2D[] collisionObj = Physics2D.OverlapCircleAll(transform.position, radioExplision, capasObjetos);
        foreach (Collider2D objeto in collisionObj)
        {
            Debug.Log("Objeto colisionado: " + objeto.gameObject.name);
            objeto.gameObject.GetComponent<HealthSystem>().TakeDamage(damage);
        }
        Instantiate(particleSistem, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
    
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radioExplision);
    }
    


    }
