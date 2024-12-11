using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthHeart : MonoBehaviour
{
    [SerializeField] private Sprite fullGear, emptyGear;
    private Image GearImage;

    void Awake()
    {
        GearImage = GetComponent<Image>();
    }
    public void SetHeartImage(HeartStatus status)
    {
        switch (status)
        {
            case HeartStatus.Empty:
                GearImage.sprite = emptyGear;
                break;
            case HeartStatus.Full:
                GearImage.sprite = fullGear;
                break;
        }
    }
}

public enum HeartStatus
{
    Empty = 0,
    Full = 1,
}

public static class HeartStatusExtensions
{
    public static int StatesPerHeart()
    {
        return System.Enum.GetValues(typeof(HeartStatus)).Length - 1; // Excluye el estado 'Empty'
    }
}
