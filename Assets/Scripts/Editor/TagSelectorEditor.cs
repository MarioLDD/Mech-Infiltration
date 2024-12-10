using UnityEditor;
using UnityEngine;
using System.Reflection;

[CustomEditor(typeof(MonoBehaviour), true)]  // Aplica a todas las clases que hereden de MonoBehaviour
public class TagSelectorEditor : Editor
{
    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        // Iterar sobre las propiedades de la clase
        var iterator = serializedObject.GetIterator();
        iterator.NextVisible(true);  // Salta el primer campo (el propio objeto MonoBehaviour)

        // Itera por todos los campos de la clase
        while (iterator.NextVisible(false))
        {
            // Obtener el campo de la clase
            var field = target.GetType().GetField(iterator.name, BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);

            // Verificar si el campo tiene el atributo TagSelector
            var attribute = field.GetCustomAttribute<TagSelectorAttribute>();

            if (attribute != null)
            {
                // Si el campo tiene el atributo TagSelector, mostrar un desplegable con los tags disponibles
                string[] tags = new string[UnityEditorInternal.InternalEditorUtility.tags.Length + 1];
                tags[0] = "Untagged";  // Agregar "Untagged" como primera opción

                // Copiar los tags existentes
                UnityEditorInternal.InternalEditorUtility.tags.CopyTo(tags, 1);

                // Obtener el tag actual
                string currentTag = iterator.stringValue;

                // Si el tag actual no está en los tags disponibles, usar "Untagged"
                if (string.IsNullOrEmpty(currentTag) || !System.Array.Exists(tags, tag => tag == currentTag))
                {
                    currentTag = "Untagged";
                }

                // Mostrar el desplegable con la opción "Untagged" primero
                int selectedIndex = System.Array.IndexOf(tags, currentTag);
                selectedIndex = EditorGUILayout.Popup(iterator.displayName, selectedIndex, tags);

                // Asignar el tag seleccionado
                iterator.stringValue = tags[selectedIndex];
            }
            else
            {
                // Si no tiene el atributo, mostrar el campo normalmente
                EditorGUILayout.PropertyField(iterator, true);
            }
        }

        serializedObject.ApplyModifiedProperties();
    }
}
