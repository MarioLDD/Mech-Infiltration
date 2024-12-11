using UnityEngine;
using UnityEngine.Events;

public class HealthSystem : MonoBehaviour, IHealthSystem
{
    [SerializeField] protected int maxHealth;
    [SerializeField] protected int currentHealth;
    [SerializeField] public UnityEvent onHealthZero;
    protected IHealthBar iHealthBar;

    public int MaxHealth
    {
        get
        {
            return maxHealth;
        }
        set
        {
            maxHealth = value;
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
            return currentHealth;
        }
        set
        {
            currentHealth = value;
            if (iHealthBar != null)
            {
                iHealthBar.UpdateHealthBar(maxHealth, currentHealth);
            }
        }
    }

    protected virtual void Start()
    {
        currentHealth = maxHealth;
        if (TryGetComponent(out IHealthBar _IHealthBar))
        {
            iHealthBar = _IHealthBar;
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
            Debug.Log($"{gameObject.name} TakeDamage");
            OnHealthZero();
        }
    }

    protected virtual void OnHealthZero()
    {
        onHealthZero?.Invoke();
    }

}