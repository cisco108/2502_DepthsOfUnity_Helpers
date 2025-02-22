using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.Networking;

public static class ExtensionMethods
{
    public static Dictionary<string, GameObject> ArrayToDict(this GameObject[] arr)
    {
        Dictionary<string, GameObject> dictionary = new();
        foreach (var gO in arr)
        {
            dictionary.Add(gO.name, gO);
        }

        return dictionary;
    }

    public static void LookAtCamera(this Transform transform)
    {
        transform.LookAt(Camera.main.transform);
    }

    public static void ResetRotation(this Transform transform)
    {
        transform.rotation = Quaternion.identity;
    }

    public static void LogInfo(this GameObject gO)
    {
        Debug.Log($"Name: {gO.name} \n" +
                  $"Position: {gO.transform.position} \n" +
                  $"Active: {gO.activeSelf}");
    }

    public static void PrintJoke(this GameObject gameObject)
    {
        string url = "https://api.chucknorris.io/jokes/random";
        var webRequest = UnityWebRequest.Get(url);
        var request = webRequest.SendWebRequest();

        while (!request.isDone)
        {
            System.Threading.Thread.Sleep(100);
        }

        var json = webRequest.downloadHandler.text;
        var data = JsonUtility.FromJson<Response>(json);
        Debug.Log($"The {gameObject.name} has a joke to tell: {data.value}");
    }

    public static void Log(this object o)
    {
        Debug.Log(o);
    }

    public static void WriteToTempFile(this object o)
    {
        var path = Path.Combine(Directory.GetCurrentDirectory(), "temp.txt");
        File.AppendAllLines(path, new[] { o.ToString() });
        Debug.Log($"Wrote content to: {path}");
    }

    public static void ResetChildrenTransform(this Transform gO, bool resetPos, bool resetRot)
    {
        int childCount = gO.childCount;

        for (int i = 0; i < childCount; i++)
        {
           gO.GetChild(i).localPosition = Vector3.zero; 
        }
        
    }
    


    /////////////////// From the Lectures /////////////////////////////////////
    public static T GetOrAddComponent<T>(this GameObject gameObject) where T : MonoBehaviour
    {
        var component = gameObject.GetComponent<T>();
        if (!component) gameObject.AddComponent<T>();
        return component;
    }

    /////////////////// From Perplexity.ai /////////////////////////////////////
    public static void LookAtY(this Transform transform, Vector3 target)
    {
        Vector3 targetPosition = new Vector3(target.x, transform.position.y, target.z);
        transform.LookAt(targetPosition);
        Vector3 eulerAngles = transform.eulerAngles;
        transform.eulerAngles = new Vector3(0, eulerAngles.y, 0);
    }
}