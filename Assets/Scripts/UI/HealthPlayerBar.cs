using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPlayerBar : MonoBehaviour
{
    [SerializeField] private GameObject heartPrefab;
    private List<HealthHeart> hearts = new List<HealthHeart>();
    private int statesPerHeart;
    private void Awake()
    {
        statesPerHeart = HeartStatusExtensions.StatesPerHeart();
    }

    private void OnEnable()
    {
        PlayerHealthBar.OnUpdateHealthBar += DrawHearts;
    }

    private void OnDisable()
    {
        PlayerHealthBar.OnUpdateHealthBar -= DrawHearts;
    }
    public void DrawHearts(int maxHealth, int currentHealth)
    {
        ClearHearts();

        int numHearts = Mathf.CeilToInt((float)maxHealth / statesPerHeart);
        for (int i = 0; i < maxHealth; i++)
        {
            CreateEmptyHeart();
        }

        for (int i = 0; i < hearts.Count; i++)
        {
            int heartStausRemainder = Mathf.Clamp(currentHealth - i * statesPerHeart, 0, statesPerHeart);
            hearts[i].SetHeartImage((HeartStatus)heartStausRemainder);
        }
    }
    public void CreateEmptyHeart()
    {
        GameObject newHeart = Instantiate(heartPrefab);
        newHeart.transform.SetParent(transform);

        HealthHeart heartComponent = newHeart.GetComponent<HealthHeart>();
        heartComponent.SetHeartImage(HeartStatus.Empty);
        hearts.Add(heartComponent);
    }
    public void ClearHearts()
    {
        foreach (Transform t in transform)
        {
            Destroy(t.gameObject);
        }
        hearts = new List<HealthHeart>();
    }
}
