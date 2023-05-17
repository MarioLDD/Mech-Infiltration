using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthSystemBoss : MonoBehaviour
{
    public int maxHealth = 3;
    private int currentHealth;
    public bool walls = false;
    public bool boss = false;
    public bool player = false;

    private SpriteRenderer spriteWalls;

    private FloatingHealthBar healthBar;
    private FloatingHealthBarWALL healthBarW;
    public CamaraPosition camaraPosition;
    public GameObject canvas;

    // Start is called before the first frame update
    void Start()
    {

        
        currentHealth = maxHealth;


        if (!walls)
        {
            healthBar = GetComponentInChildren<FloatingHealthBar>();
            if (healthBar != null)
            {
                healthBar.UpdateHealthBar(currentHealth, maxHealth);

            }
        }
        else
        {
            canvas.SetActive(false);
            healthBarW = GetComponentInChildren<FloatingHealthBarWALL>();

            spriteWalls = GetComponent<SpriteRenderer>();
        }

        

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void TakeDamage(int damageAmount)
    {

        currentHealth -= damageAmount;
        if (!walls)
        {
            if (healthBar != null)
            {
                healthBar.UpdateHealthBar(currentHealth, maxHealth);

            }
            if (currentHealth <= 0)
            {
                if(!boss)
                {
                    Destroy(gameObject);

                }
                else if(!player)
                {
                    SceneManager.LoadScene("GameOverMenu");

                }
                else
                {
                    SceneManager.LoadScene("VictoryMenu");
                }
            }
        }
        else
        {
            canvas.SetActive(true);
            //healthBarW = GetComponentInChildren<FloatingHealthBarWALL>();
            spriteWalls.color = Color.red;
            StartCoroutine(Espera());
            
           
                GetComponentInChildren<FloatingHealthBarWALL>().UpdateHealthBar(currentHealth, maxHealth);

            
            if (currentHealth <= 0)
            {
                camaraPosition.walls = false;
                Destroy(gameObject);
            }
        }

    }

    IEnumerator Espera()
    {
        yield return new WaitForSecondsRealtime(0.05f);
        spriteWalls.color = Color.white;
    }



}
