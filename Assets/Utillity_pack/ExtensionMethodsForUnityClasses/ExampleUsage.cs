using UnityEngine;

public class ExampleUsage : MonoBehaviour
{

    public GameObject[] gameObjects;
    private void Start()
    {
      TestLoggingExtensions(); 
      TestArrayToDict();
       
    }

    private void TestLoggingExtensions()
    {
        //To Unity Console
       gameObject.LogInfo(); 
       
       "hello".Log();
       1.Log();
       42.0.Log();
       gameObject.Log();
        
       //To temp.txt
       "Hello file writer!".WriteToFile();
       42.WriteToFile();
       gameObject.name.WriteToFile();
    }

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