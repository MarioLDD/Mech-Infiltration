using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthSystemWalls : MonoBehaviour, IHealthSystem
{
    public int maxHealth = 700;
    private int currentHealth;

    private SpriteRenderer spriteWalls;

    public FloatingHealthBarWALL healthBarW;
    public CamaraPosition camaraPosition;
    public GameObject canvas;

    // Start is called before the first frame update
    void Start()
    {


        currentHealth = maxHealth;


        spriteWalls = GetComponent<SpriteRenderer>();

        canvas.SetActive(false);


    }


    public void TakeDamage(int damageAmount)
    {
        canvas.SetActive(true);
        healthBarW = GetComponentInChildren<FloatingHealthBarWALL>();
        if(healthBarW != null)
        {
            Debug.Log("hola" + currentHealth + " / " + maxHealth);
        }
        currentHealth -= damageAmount;
        spriteWalls.color = Color.red;
        StartCoroutine(Espera());

        healthBarW.UpdateHealthBar(currentHealth, maxHealth);


        if (currentHealth <= 0)
        {
            camaraPosition.walls = false;
            Destroy(gameObject);
        }


    }

    IEnumerator Espera()
    {
        yield return new WaitForSecondsRealtime(0.05f);
        spriteWalls.color = Color.white;
    }



}
