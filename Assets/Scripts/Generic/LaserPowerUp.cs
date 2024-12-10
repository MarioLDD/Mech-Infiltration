using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserPowerUp : PowerUp
{
    public override string powerUpName => "Laser";

    public override void Activate(PlayerController playerController)
    {
        Debug.Log("Laser Activado");

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerController playerController))
        {
            Activate(playerController);
        }
    }
}