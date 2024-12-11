using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootSpawner : MonoBehaviour
{
    [SerializeField] private GameObject lootPrefab;

    public void SpawnLoot()
    {
        Instantiate(lootPrefab,transform.position,Quaternion.identity);
    }
}