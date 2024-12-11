using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class ArcPrefabSpawner2D : MonoBehaviour
{
    [Header("Prefab and Placement Settings")]
    [SerializeField] private GameObject prefab; // Prefab a instanciar.
    [SerializeField] private float radius = 5f; // Radio del arco.
    [SerializeField] private float startAngle = 0f; // Ángulo inicial en grados.
    [SerializeField] private float arcAngle = 90f; // Ángulo total del arco.
    [SerializeField] private float stepAngle = 10f; // Separación angular entre instancias.

    [Header("Options")]
    [SerializeField] private bool clearPrevious = true; // Limpiar instancias previas antes de generar nuevas.

    public void GeneratePrefabs()
    {
        if (prefab == null)
        {
            Debug.LogError("Prefab is not assigned.");
            return;
        }

        if (clearPrevious)
        {
            ClearInstances();
        }

        // Crear las instancias en el arco
        for (float angle = startAngle; angle <= startAngle + arcAngle; angle += stepAngle)
        {
            Vector3 position = GetPositionOnArc(radius, angle);

#if UNITY_EDITOR
            // Usar PrefabUtility para instanciar el prefab en el editor
            GameObject instance = (GameObject)PrefabUtility.InstantiatePrefab(prefab, transform);
#else
            // Instanciar de manera convencional si no estás en el editor
            GameObject instance = Instantiate(prefab, transform);
#endif

            instance.transform.position = position;

            // Ajustar la rotación para mirar hacia el centro del círculo
            Vector2 directionToCenter = (Vector2)(transform.position - instance.transform.position).normalized;
            float rotationAngle = Mathf.Atan2(directionToCenter.y, directionToCenter.x) * Mathf.Rad2Deg;
            instance.transform.rotation = Quaternion.Euler(0f, 0f, rotationAngle);
        }

        Debug.Log("Prefabs generated along the arc.");
    }

    // Limpia las instancias previas (hijos del objeto padre)
    private void ClearInstances()
    {
        for (int i = transform.childCount - 1; i >= 0; i--)
        {
            DestroyImmediate(transform.GetChild(i).gameObject);
        }
    }

    // Calcula la posición en el arco basado en el ángulo y radio
    private Vector3 GetPositionOnArc(float radius, float angle)
    {
        float radians = angle * Mathf.Deg2Rad;
        return new Vector3(
            Mathf.Cos(radians) * radius,
            Mathf.Sin(radians) * radius,
            0f
        ) + transform.position; // Ajustar según la posición del padre.
    }
}
