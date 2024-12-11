using UnityEngine;

public class KeyPickup : MonoBehaviour
{
    [SerializeField] private KeyType keyType;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (collision.TryGetComponent(out PlayerInventory playerInventory))
            {
                playerInventory.CollectKey(keyType);
                Destroy(gameObject);
            }
        }
    }
}
