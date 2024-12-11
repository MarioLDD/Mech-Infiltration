using UnityEngine;

public interface IPooledObject
{
    public GameObject OriginPrefab { set ; }
}


/// <summary>
/// private GameObject originPrefab;
/// public GameObject OriginPrefab { set => originPrefab = value; }
/// 
/// 
/// ObjectPool.Instance.ReturnObject(originPrefab, this.gameObject);
/// 
/// </summary>