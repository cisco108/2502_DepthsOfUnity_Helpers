using System.Reflection;
using UnityEngine;

public abstract class AutoInitPrivateComponentFields : MonoBehaviour
{
    protected virtual void Awake()
    {
        InitializeComponents();
    }

    private void InitializeComponents()
    {
        FieldInfo[] fields = GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance);

        foreach (FieldInfo field in fields)
        {
            if (typeof(Component).IsAssignableFrom(field.FieldType))
            {
                Component component = GetComponent(field.FieldType);
                if (!component)
                {
                    gameObject.AddComponent(field.FieldType);
                    component = GetComponent(field.FieldType);
                    Debug.LogWarning(
                        $"Component {field.FieldType} was missing and dynamically added on {gameObject}, check its configuration!");
                }

                Debug.Log($"{field.FieldType} was initialized in {this}");
                field.SetValue(this, component);
            }
        }
    }
}