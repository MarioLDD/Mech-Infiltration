using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthSystem : MonoBehaviour, IHealthSystem
{
    public int maxHealth = 3;
    [SerializeField] private int currentHealth;
    public int CurrenHealth { set => currentHealth = value; }
    public bool player = false;
    public bool boss = false;
    public bool modoDios = false;
    public List<GameObject> vidaUI;


    private FloatingHealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        modoDios = false;
        currentHealth = maxHealth;
        healthBar = GetComponentInChildren<FloatingHealthBar>();
        if (healthBar != null)
        {
            healthBar.UpdateHealthBar(currentHealth, maxHealth);
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            modoDios = true;
        }

        if (modoDios && player)
        {
            currentHealth = maxHealth;
        }


    }
    public void TakeDamage(int damageAmount)
    {
       
        currentHealth -= damageAmount;
        
        
            if (healthBar != null)
            {
                healthBar.UpdateHealthBar(currentHealth, maxHealth);
            }

            if (player)
            {
                vidaUI[currentHealth].SetActive(false);
                Debug.Log(currentHealth);
            }

            if (currentHealth <= 0)
            {
                if (player)
                {
                    SceneManager.LoadScene("GameOverMenu");
                }
                else if (boss)
                {
                    //explosiones
                    Destroy(gameObject);
                }
                else
                {
                    Destroy(gameObject);
                }
            }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (player && collision.gameObject.CompareTag("Life"))
        {
            if (currentHealth < 5)
            {
                vidaUI[currentHealth].SetActive(true);
                currentHealth++;
                Debug.Log(currentHealth);

                Destroy(collision.gameObject);
            }

        }
    }





}
