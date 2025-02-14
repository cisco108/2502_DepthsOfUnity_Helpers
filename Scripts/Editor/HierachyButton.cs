using UnityEngine;
using UnityEditor;

[InitializeOnLoad]
public class HierarchyButton
{
    static HierarchyButton()
    {
        EditorApplication.hierarchyWindowItemOnGUI += OnHierarchyGUI;
    }

    static void OnHierarchyGUI(int instanceID, Rect selectionRect)
    {
        GameObject obj = EditorUtility.InstanceIDToObject(instanceID) as GameObject;
        if (obj != null && obj.GetComponent<ExampleUsage>())
        {
            Rect buttonRect = new Rect(selectionRect.x + selectionRect.width - 50, selectionRect.y, 50, 16);

            if (GUI.Button(buttonRect, "Btn"))
            {
                Debug.Log($"Button clicked on {obj.name}");
            }
        }
    }
}