using System;
using System.Collections.Generic;
using UnityEngine;

public interface IEvent
{
    void Invoke();

    void AddListener(IEventListener listener);
    void RemoveListener(IEventListener listener);
}

public interface IEventListener
{
    void OnInvoke();

    public void Subscribe()
    {
        Debug.Log($"{this} Subscribe()");
    }

    public void Unsubscribe();
}

[UnityEngine.CreateAssetMenu(fileName = "Event", menuName = "Scriptables/ScriptableEvents", order = 0)]
public class ScriptableEvent : UnityEngine.ScriptableObject, IEvent
{
    [SerializeField] private string inspectorName = "Event";
    [SerializeReference] private List<IEventListener> _listeners = new();

    public IList<IEventListener> Listeners => _listeners;

    public void RemoveListener(IEventListener listener)
    {
        Listeners.Remove(listener);
    }

    public void AddListener(IEventListener listener)
    {
        Listeners.Add(listener);
    }

    public static ScriptableEvent operator +(ScriptableEvent instance, IEventListener listener)
    {
        Debug.Log($"ScriptableEvent += {listener}");
        instance.AddListener(listener);
        return instance;
    }

    public static ScriptableEvent operator -(ScriptableEvent instance, IEventListener listener)
    {
        instance.RemoveListener(listener);
        return instance;
    }

    [Button("Yoo")]
    public void Invoke()
    {
        Debug.Log($"Invoked from {this}");
        foreach (var listener in Listeners)
        {
            listener.OnInvoke();
        }
    }

    private void OnValidate()
    {
        inspectorName = name;
    }
}