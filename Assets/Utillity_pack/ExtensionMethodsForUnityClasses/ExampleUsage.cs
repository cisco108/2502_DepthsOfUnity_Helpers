using UnityEngine;

public class ExampleUsage : AutoInitPrivateComponentFields
{
    private MeshRenderer _renderer;

    private void Start()
    {
      TestLoggingExtensions(); 
       
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
}