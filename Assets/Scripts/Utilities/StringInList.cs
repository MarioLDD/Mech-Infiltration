using System;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

/// <summary>
/// Crea en el editor un selector con opciones.
/// </summary>
public class StringInList : PropertyAttribute
{
    public delegate string[] GetStringList();

    /// <summary>
    /// Muestra un selector con opciones.
    /// </summary>
    /// <param name="list">Opciones</param>
    public StringInList(params string[] list)
    {
        List = list;
    }

    /// <summary>
    /// Crea un selector a partir de la lista que devuelve el método invocado.
    /// </summary>
    /// <param name="type">Clase generadora</param>
    /// <param name="methodName">Nombre del método generador</param>
    public StringInList(Type type, string methodName)
    {
        var method = type.GetMethod(methodName);
        if (method != null)
        {
            List = method.Invoke(null, null) as string[];
            if (List.Length == 0) List = new[] { "" };
        }
        else
        {
            Debug.LogError("No existe el método " + methodName + " en " + type);
        }
    }

    public string[] List
    {
        get;
        private set;
    }
}

#if UNITY_EDITOR
[CustomPropertyDrawer(typeof(StringInList))]
public class StringInListDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        var stringInList = attribute as StringInList;
        var list = stringInList.List;
        if (property.propertyType == SerializedPropertyType.String)
        {
            int index = Mathf.Max(0, Array.IndexOf(list, property.stringValue));
            index = EditorGUI.Popup(position, property.displayName, index, list);

            property.stringValue = list[index];
        }
        else if (property.propertyType == SerializedPropertyType.Integer)
        {
            property.intValue = EditorGUI.Popup(position, property.displayName, property.intValue, list);
        }
        else
        {
            base.OnGUI(position, property, label);
        }
    }
}
#endif