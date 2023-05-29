using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystemDestroyer : MonoBehaviour
{
    private ParticleSystem particleSystemExplosion;

    private void Start()
    {
        particleSystemExplosion = GetComponent<ParticleSystem>();
    }

    private void Update()
    {
        // Verificar si el Particle System ha terminado de reproducirse
        if (!particleSystemExplosion.IsAlive())
        {
            // Destruir el objeto que contiene el Particle System
            Destroy(gameObject);
        }
    }
}
