using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private HashSet<KeyType> collectedKeys = new HashSet<KeyType>();

    public void CollectKey(KeyType keyType)
    {
        if (collectedKeys.Add(keyType))
        {
            Debug.Log($"Collected: {keyType}");
        }
    }
    public void DeleteKey(KeyType keyType)
    {
        if (collectedKeys.Remove(keyType))
        {
            Debug.Log($"Deleted: {keyType}");
        }
    }

    public bool HasKey(KeyType keyType)
    {
        return collectedKeys.Contains(keyType);
    }
}
