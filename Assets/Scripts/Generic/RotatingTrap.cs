using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RotatingTrap : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 0.2f;
    [SerializeField] private int damage = 3;

    private void Update()
    {
        RotateTrap();
    }

    // Método para hacer girar la plataforma
    private void RotateTrap()
    {
        transform.Rotate(Vector3.back, rotationSpeed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (collision.gameObject.TryGetComponent(out IHealthSystem healthSystem))
            {
                healthSystem.TakeDamage(damage);
            }
        }
    }  
}