using UnityEngine;

public class ExampleUsage : MonoBehaviour
{
    public GameObject[] gameObjects;
    
    [Button("Log to Temp File")]
    private void TestLoggingToConsole()
    {
        //To Unity Console
        gameObject.LogInfo();

        "hello".Log();
        1.Log();
        42.0.Log();
        gameObject.Log();
    }

    [Button("Log to Console")]
    public void TestLoggingToFile()
    {
        //To temp.txt
        "Hello file writer!".WriteToFile();
        42.WriteToFile();
        gameObject.name.WriteToFile();
    }

    [Button("Save GameObject[] to Dictionary")]
    private void TestArrayToDict()
    {
        var newDict = gameObjects.ArrayToDict();
        foreach (var o in newDict)
        {
            Debug.Log(o.Key + "\n" + o.Value);
        }

        GameObject markObject = newDict["momo"];
        markObject.SetActive(false);
    }
}