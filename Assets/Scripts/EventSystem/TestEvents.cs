using System;
using UnityEngine;

public class TestEvents : MonoBehaviour
{
    public ScriptableEvent myEvent;

    // [Button("Invoke")]
    public void Invoke()
    {
        Debug.Log($"Sers");
    }

    [InfoBox("foo")]
    void Foo()
    {
        Debug.Log($"{this} foo");
    }

     [Button("Hello New York")]
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            myEvent.Invoke();
        }
    }
}