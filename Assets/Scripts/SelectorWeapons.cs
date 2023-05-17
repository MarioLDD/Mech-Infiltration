using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectorWeapons : MonoBehaviour
{
    public GameObject weaponLaser_Simple;
    public GameObject weaponLaser_Double;
    public GameObject missileLauncher_Simple;
    public GameObject missileLauncher_Double;

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
        if (collision.gameObject.CompareTag("WeaponLaser_Double"))
        {
            weaponLaser_Simple.SetActive(false);
            weaponLaser_Double.SetActive(true);
        }

        if (collision.gameObject.CompareTag("MissileLauncher_Double"))
        {
            missileLauncher_Simple.SetActive(false);
            missileLauncher_Double.SetActive(true);
        }

        Destroy(collision.gameObject);
    }
}
