using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystemDestroyer : MonoBehaviour
{
    private ParticleSystem particleSystem;

    private void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();
    }

    private void Update()
    {
        // Verificar si el Particle System ha terminado de reproducirse
        if (!particleSystem.IsAlive())
        {
            // Destruir el objeto que contiene el Particle System
            Destroy(gameObject);
        }
    }
}
