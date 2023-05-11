using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectorWeapons : MonoBehaviour
{
    public GameObject[] weapon;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PowerUps_Arma2T1"))
        {
            for (int i = 0; i < weapon.Length; i++)
            {
                weapon[i].SetActive(false);
            }
            weapon[1].SetActive(true);
        }

        if (collision.gameObject.CompareTag("PowerUps_Arma2T2"))
        {
            for (int i = 0; i < weapon.Length; i++)
            {
                weapon[i].SetActive(false);
            }
            weapon[3].SetActive(true);
        }









        Destroy(collision.gameObject);



    }
}
