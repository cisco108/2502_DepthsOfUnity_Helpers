using UnityEngine;
using UnityEditor;

[InitializeOnLoad]
public class HierarchyColor
{
    static HierarchyColor()
    {
        EditorApplication.hierarchyWindowItemOnGUI += OnHierarchyGUI;
    }

    static void OnHierarchyGUI(int instanceID, Rect selectionRect)
    {
        GameObject obj = EditorUtility.InstanceIDToObject(instanceID) as GameObject;
        if (obj != null && (obj.GetComponent<ObjectPoolComponent>() 
                            || obj.GetComponent<ExampleUsage>()
                            || obj.GetComponent<ParentingHelper>()))
        {
            // Change background color
            EditorGUI.DrawRect(selectionRect, Color.cyan);

            // Change text color
            var style = new GUIStyle();
            style.normal.textColor = Color.black;
            EditorGUI.LabelField(selectionRect, obj.name, style);
        }
    }
}
