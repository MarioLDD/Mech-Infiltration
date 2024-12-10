using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHealthBar
{
    void UpdateHealthBar(int maxHealth, int currentHealth);
}
