using UnityEngine;
using System.IO;

public static class ExtensionMethods
{
    public static T GetOrAddComponent<T>(this GameObject gameObject) where T : MonoBehaviour
    {
        var component = gameObject.GetComponent<T>();
        if (component == null) gameObject.AddComponent<T>();
        return component;
    }


    public static void LogInfo(this GameObject gO)
    {
        Debug.Log($"Name: {gO.name} \n" +
                  $"Position: {gO.transform.position} \n" +
                  $"Active: {gO.activeSelf}");
    }

    public static void LookAtY(this Transform transform, Vector3 target)
    {
        Vector3 targetPosition = new Vector3(target.x, transform.position.y, target.z);
        transform.LookAt(targetPosition);
        Vector3 eulerAngles = transform.eulerAngles;
        transform.eulerAngles = new Vector3(0, eulerAngles.y, 0);
    }

    public static void Log(this object o)
    {
        Debug.Log(o);
    }

    public static void WriteToFile(this object o)
    {
        var path = Path.Combine(Directory.GetCurrentDirectory(), "temp.txt");
        File.AppendAllLines(path, new[] { o.ToString() });
    }
}