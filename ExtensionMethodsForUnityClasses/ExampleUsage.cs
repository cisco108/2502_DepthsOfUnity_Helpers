using UnityEngine;

public class ExampleUsage : MonoBehaviour
{
    public GameObject[] gameObjects;
    
    [Button("Log to Console")]
    private void TestLoggingToConsole()
    {
        //To Unity Console
        gameObject.LogInfo();

        "hello".Log();
        1.Log();
        42.0.Log();
        gameObject.Log();
    }

    [Button("Log to Temp File")]
    public void TestLoggingToFile()
    {
        //To temp.txt
        "Hello file writer!".WriteToTempFile();
        42.WriteToTempFile();
        gameObject.name.WriteToTempFile();
    }

  

    [InfoBox(" With this Example Class you can try all the \n" +
             " Unity Extension methods, included in the Package.")]
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