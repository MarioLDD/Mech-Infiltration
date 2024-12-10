using System;
using UnityEngine;

[AttributeUsage(AttributeTargets.Field, Inherited = true, AllowMultiple = false)]
public class TagSelectorAttribute : PropertyAttribute
{
    // Este atributo no necesita par�metros, solo marca los campos donde se utilizar� el sistema de tags.
}
