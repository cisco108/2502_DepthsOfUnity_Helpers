#if UNITY_EDITOR

using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Object), true)]
[CanEditMultipleObjects]
public class InfoDrawer : Editor
{
    public Texture2D tex;
    public override void OnInspectorGUI()
    {
        // base.OnInspectorGUI();
        DrawDefaultInspector();

        var monoTarget = target as MonoBehaviour;
        if (monoTarget)
        {
            DrawInfoBox(target);
        }
        
        
        var mono = target as MonoBehaviour;
        if (mono)
        {
            DrawButton(mono);
        }
    }

    private void DrawInfoBox(Object o)
    {
        var methodInfos = target.GetType().GetMethods(System.Reflection.BindingFlags.Instance |
                                                      System.Reflection.BindingFlags.Public |
                                                      System.Reflection.BindingFlags.NonPublic |
                                                      System.Reflection.BindingFlags.Static);
        foreach (var methodInfo in methodInfos)
        {
            var attributes = methodInfo.GetCustomAttributes(typeof(InfoBoxAttribute), true);
            if (attributes.Length > 0)
            {
                var infoBoxAttribute = attributes[0] as InfoBoxAttribute;
                GUILayout.Box(new GUIContent(infoBoxAttribute.Info, tex));
            }
        }
    }
    
    
    void DrawButton(Object o)
    {
        var methodInfos = target.GetType().GetMethods(System.Reflection.BindingFlags.Instance |
                                                      System.Reflection.BindingFlags.Public |
                                                      System.Reflection.BindingFlags.NonPublic |
                                                      System.Reflection.BindingFlags.Static);
        foreach (var methodInfo in methodInfos)
        {
            var attributes = methodInfo.GetCustomAttributes(typeof(ButtonAttribute), true);
            if (attributes.Length > 0)
            {
                var buttonAttribute = attributes[0] as ButtonAttribute;
                string label = string.IsNullOrEmpty(buttonAttribute.Label) ?
                    methodInfo.Name : buttonAttribute.Label;

                if (GUILayout.Button(label))
                {
                    methodInfo.Invoke(target, null);
                }
            }
        } 
    }
}
#endif