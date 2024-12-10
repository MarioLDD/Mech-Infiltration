using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ArcPrefabSpawner2D))]
public class ArcPrefabSpawner2DEditor : Editor
{
    public override void OnInspectorGUI()
    {
        // Referencia al script
        ArcPrefabSpawner2D spawner = (ArcPrefabSpawner2D)target;

        // Dibujar el inspector original
        DrawDefaultInspector();

        // Botón para generar prefabs
        if (GUILayout.Button("Generate Prefabs"))
        {
            spawner.GeneratePrefabs();
        }
    }
}
