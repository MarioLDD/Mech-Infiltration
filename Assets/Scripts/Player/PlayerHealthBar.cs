using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthBar : MonoBehaviour, IHealthBar
{
    public static event Action<int, int> OnUpdateHealthBar;

    public void UpdateHealthBar(int maxHealth, int currentHealth)
    {
        OnUpdateHealthBar?.Invoke(maxHealth, currentHealth);
    }
}