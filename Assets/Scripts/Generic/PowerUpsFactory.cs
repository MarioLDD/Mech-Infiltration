using System.Collections.Generic;
using UnityEngine;

public class PowerUpsFactory : MonoBehaviour
{

    [SerializeField] private PowerUp[] powerUps;
    private Dictionary<string, PowerUp> powerUpsDictionary;

    private void Awake()
    {
        powerUpsDictionary = new Dictionary<string, PowerUp>();
        foreach (var powerUp in powerUps)
        {
            powerUpsDictionary.Add(powerUp.powerUpName, powerUp);
        }
    }



    public PowerUp CreatePowerUp(string powerUpName, Transform playerTransform)
    {
        if (powerUpsDictionary.TryGetValue(powerUpName, out PowerUp skillPrefab))
        {
            PowerUp powerUpInstance = Instantiate(skillPrefab, playerTransform.position, Quaternion.identity);
            return powerUpInstance;
        }
        else
        {
            Debug.LogWarning($"La habilidad '{powerUpName}' no existe en la base de datos de habilidades.");
            return null;
        }
    }
}