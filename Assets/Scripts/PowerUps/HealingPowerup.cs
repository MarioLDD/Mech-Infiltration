using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingPowerup : MonoBehaviour, IPowerUp<HealthSystem>
{

    [SerializeField] private int healingValue = 1;

    public void Activate(HealthSystem healthSystem)
    {
        if (healthSystem.CurrentHealth == healthSystem.MaxHealth)
        {
            return;
        }

        healthSystem.CurrentHealth = Mathf.Min(healthSystem.CurrentHealth + healingValue, healthSystem.MaxHealth);

        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && collision.TryGetComponent(out HealthSystem healthSystem))
        {
            Activate(healthSystem);
        }
    }
}