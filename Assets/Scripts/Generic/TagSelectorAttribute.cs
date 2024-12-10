using System;
using UnityEngine;

[AttributeUsage(AttributeTargets.Field, Inherited = true, AllowMultiple = false)]
public class TagSelectorAttribute : PropertyAttribute
{
    // Este atributo no necesita parámetros, solo marca los campos donde se utilizará el sistema de tags.
}
