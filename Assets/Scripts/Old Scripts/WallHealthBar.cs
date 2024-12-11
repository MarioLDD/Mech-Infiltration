using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WallHealthBar : MonoBehaviour, IHealthBar
{
    private Slider slider;

    void Start()
    {
        slider = GetComponent<Slider>();
    }

    public void UpdateHealthBar(int currentValue, int maxValue)
    {
        slider.value = currentValue / maxValue;
    }
}
