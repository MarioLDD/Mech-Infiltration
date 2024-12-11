
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private KeyType requiredKeyType;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerInventory playerInventory))
        {
            if (playerInventory.HasKey(requiredKeyType))
            {
                OpenDoor();

                playerInventory.DeleteKey(requiredKeyType);
            }
            else
            {
                WrongKey();
            }
        }
    }

    public void OpenDoor()
    {
        Debug.Log("Door opened!");

        Destroy(gameObject);
    }

    private void WrongKey()
    {
        Debug.Log("You need the correct key to open this door.");

    }
}
