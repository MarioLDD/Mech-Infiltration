using UnityEngine;
using UnityEngine.Events;

public class NewHealthSystem : MonoBehaviour
{
    [SerializeField] protected int maxHealth;
    [SerializeField] protected int currentHealth;
    [SerializeField] protected UnityEvent onHealthZero;
    protected IHealthBar iHealthBar;

    public int MaxHealth
    {
        get
        {
            return (maxHealth / 4);
        }
        set
        {
            maxHealth = value * 4;
            if (iHealthBar != null)
            {
                iHealthBar.UpdateHealthBar(maxHealth, currentHealth);
            }
        }
    }

    public int CurrentHealth
    {
        get
        {
            return (currentHealth / 4);
        }
        set
        {
            currentHealth = value * 4;
            if (iHealthBar != null)
            {
                iHealthBar.UpdateHealthBar(maxHealth, currentHealth);
            }
        }
    }

    protected virtual void Start()
    {
        currentHealth = maxHealth;
        if (GetComponentInChildren<IHealthBar>() != null)
        {
            iHealthBar = GetComponentInChildren<IHealthBar>();
            iHealthBar.UpdateHealthBar(maxHealth, currentHealth);
        }
    }

    public virtual void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (iHealthBar != null)
        {
            iHealthBar.UpdateHealthBar(maxHealth, currentHealth);
        }

        if (currentHealth < 1)
        {
            OnHealthZero();
        }
    }

    protected virtual void OnHealthZero()
    {
        onHealthZero?.Invoke();
    }

}