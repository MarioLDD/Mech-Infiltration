using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public int damage = 1;
    public GameObject particleSistem;

    [StringInList("Player", "Enemy")] public string target;


    // Start is called before the first frame update
    void Start()
    {
        //Destroy(gameObject, 2f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag(target))
        {
            //Debug.Log(target);
            if (collision.gameObject.GetComponent<IHealthSystem>() != null)
            {
                collision.gameObject.GetComponent<IHealthSystem>().TakeDamage(damage);
                Instantiate(particleSistem, transform.position, Quaternion.identity);

                Destroy(gameObject);
            }
        }
        Instantiate(particleSistem, transform.position, Quaternion.identity);

        Destroy(gameObject);

    }
}
