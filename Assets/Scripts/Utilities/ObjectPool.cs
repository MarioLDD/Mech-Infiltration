using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool Instance { get; private set; }

    private Dictionary<GameObject, Queue<GameObject>> pooledObjects = new Dictionary<GameObject, Queue<GameObject>>();

    private HashSet<GameObject> prefabs = new HashSet<GameObject>();

    public void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    /// <summary>
    /// Creates a new pool for the given prefab with a specified number of inactive instances.
    /// </summary>
    /// <param name="prefab">The prefab to create the pool for.</param>
    /// <param name="poolSize">The number of instances to create for the pool.</param>
    /// <param name="container">Optional parent transform where the pooled objects will be instantiated.</param>
    public void CreatePool(GameObject prefab, int poolSize, Transform container = null)
    {
        if (prefabs.Contains(prefab))
        {
            Debug.LogWarning($"The prefab {prefab.name} is already registered in the pool.");
            return;
        }

        prefabs.Add(prefab);

        var prefabQueue = new Queue<GameObject>();
        pooledObjects[prefab] = prefabQueue;

        for (int i = 0; i < poolSize; i++)
        {
            GameObject newObject = Instantiate(prefab, container);
            newObject.SetActive(false);
            newObject.GetComponent<IPooledObject>().OriginPrefab = prefab;
            pooledObjects[prefab].Enqueue(newObject);
        }
    }

    /// <summary>
    /// Retrieves an object from the pool.
    /// </summary>
    /// <param name="prefab">The prefab of the object you want to retrieve.</param>
    /// <param name="activateOnReturn">If false, the object will return inactive. Otherwise, it return activated.</param>
    /// <returns>The object from the pool, either activated or deactivated depending on the parameter.</returns>
    public GameObject GetObject(GameObject prefab, bool activateOnReturn = true)
    {
        if (!prefabs.Contains(prefab))
        {
            Debug.LogWarning("Prefab not found in the pool. Create a new one using CreatePool.");
            return null;
        }
        GameObject objectToReturn;

        ObjectRequest(prefab, out objectToReturn);

        objectToReturn.SetActive(true);
        return objectToReturn;
    }

    /// <summary>
    /// Retrieves an object from the pool, sets its position and rotation.
    /// </summary>
    /// <param name="prefab">The prefab of the object you want to retrieve.</param>
    /// <param name="position">The position to place the object.</param>
    /// <param name="rotation">The rotation to apply to the object.</param>
    /// <param name="activateOnReturn">If false, the object will return inactive. Otherwise, it return activated.</param>
    /// <returns>The activated object from the pool, positioned and rotated as specified.</returns>
    public GameObject GetObject(GameObject prefab, Vector3 position, Quaternion rotation, bool activateOnReturn = true)
    {
        if (!prefabs.Contains(prefab))
        {
            Debug.LogWarning("Prefab not found in the pool. Create a new one using CreatePool.");
            return null;
        }
        GameObject objectToReturn;

        ObjectRequest(prefab, out objectToReturn);

        objectToReturn.transform.position = position;
        objectToReturn.transform.rotation = rotation;

        objectToReturn.SetActive(true);
        return objectToReturn;
    }

    private void ObjectRequest(GameObject prefab, out GameObject objectToReturn)
    {
        var queue = pooledObjects[prefab];

        if (queue.Count > 0)
        {
            objectToReturn = queue.Dequeue();
        }
        else
        {
            objectToReturn = Instantiate(prefab);
            objectToReturn.GetComponent<IPooledObject>().OriginPrefab = prefab;
        }
    }

    /// <summary>
    /// Returns the object to the pool, deactivates it, and adds it back to the queue.
    /// </summary>
    /// <param name="originPrefab">The original prefab associated with the pooled object.</param>
    /// <param name="prefab">The object to return to the pool.</param>
    public void ReturnObject(GameObject originPrefab, GameObject prefab)
    {
        if (prefabs.Contains(originPrefab))
        {
            prefab.SetActive(false);
            pooledObjects[originPrefab].Enqueue(prefab);
        }
        else
        {
            Debug.LogWarning("Trying to return an object that doesn't belong to the pool.");
        }
    }
}