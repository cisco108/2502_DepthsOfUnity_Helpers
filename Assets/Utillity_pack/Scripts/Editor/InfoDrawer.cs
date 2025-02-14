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
                GUILayout.Box(new GUIContent("Hello Mister good to see you in this Box! \n \n ", tex ));
                // GUILayout.Box(new GUIContent("Hello Mister good to see you in this Box! \n \n ", new Texture2D(100, 100)));
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