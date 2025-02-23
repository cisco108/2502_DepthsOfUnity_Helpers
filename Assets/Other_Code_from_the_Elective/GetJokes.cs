using System;
using UnityEngine;
using UnityEngine.InputSystem.HID;
using UnityEngine.Networking;

public class Respo
{
    public string icon_url;
    public string id;
    public string url;
    public string value;
}
public class GetJokes : MonoBehaviour
{
    private const string URL = "https://api.chucknorris.io/jokes/random";
    
    
        
    public string GetJoke()
    {
        var webRequest = UnityWebRequest.Get(URL);
        var request = webRequest.SendWebRequest();
        Debug.Log(request);
        
        while (!request.isDone)
        {
            System.Threading.Thread.Sleep(100);
        }

        var json = webRequest.downloadHandler.text;
        var data = JsonUtility.FromJson<Respo>(json);
        return data.value;
    }

    void Start()
    {
        Debug.Log(GetJoke());
    }
}