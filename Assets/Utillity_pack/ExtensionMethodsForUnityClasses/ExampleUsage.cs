using UnityEngine;

public class ExampleUsage : AutoInitPrivateComponentFields
{
    private MeshRenderer _renderer;

    private void Start()
    {
       gameObject.LogInfo(); 
    }
}