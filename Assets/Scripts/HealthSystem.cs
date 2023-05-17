using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public int maxHealth = 3;
    private int currentHealth;

    private FloatingHealthBar healthBar;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar = GetComponentInChildren<FloatingHealthBar>();
        if (healthBar != null)
        {
            healthBar.UpdateHealthBar(currentHealth, maxHealth);

        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        if (healthBar != null)
        {
            healthBar.UpdateHealthBar(currentHealth, maxHealth);

        }
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
