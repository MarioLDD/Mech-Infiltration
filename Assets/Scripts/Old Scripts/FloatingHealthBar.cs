using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingHealthBar : MonoBehaviour
{
    private Slider slider;

    public Transform transformCamera;
    public Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
        transformCamera = GameObject.FindGameObjectWithTag("MainCamera").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = transformCamera.rotation;
       // transform.position = transform.root.position + offset;
    }

    public void UpdateHealthBar(float currentValue, float maxValue)
    {
        slider.value = currentValue / maxValue;
    }
}
