using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField] private KeyType keyType;

    public void UseKey()
    {

        Debug.Log($"Used {keyType.ToString()}!");

    }
}
public enum KeyType
{
    RedKey,
    BlueKey,
}