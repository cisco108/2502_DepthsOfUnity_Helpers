using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

[Serializable]
public class EventListenerData : IEventListener
{
    [SerializeField] private ScriptableEvent @event;
    [SerializeField] private UnityEvent response;
    public event Action Response;

    public ScriptableEvent Event
    {
        get => @event;
        set => @event = value;
    }

    public void Subscribe()
    {
        Event += this;
    }

    public void Unsubscribe()
    {
        Event -= this;
    }

    public void OnInvoke()
    {
        response.Invoke();
        Response.Invoke();
    }
}

public class EventsListener : MonoBehaviour, IEventListener
{
    [SerializeField] private List<EventListenerData> eventListenerDatas = new();
    [SerializeField] private UnityEvent UnityEventResponse;

    public void MoveCube()
    {
        var cubes = GameObject.FindGameObjectsWithTag("tag");
        int randomIndex = Random.Range(0, cubes.Length);
        var pos = cubes[randomIndex].transform.position;
        pos.y += Random.Range(1, 3);
        cubes[randomIndex].transform.position = pos;
    }

    private void OnEnable()
    {
        Subscribe();
        eventListenerDatas[0].Response += MoveCube;
    }

    private void OnDisable()
    {
        Unsubscribe();
        eventListenerDatas[0].Response -= MoveCube;
    }

    public void OnInvoke()
    {
        UnityEventResponse.Invoke();
    }

    public void Subscribe()
    {
        if (eventListenerDatas == null || eventListenerDatas.Count == 0)
        {
            Debug.LogWarning($"no listeners ");
            return;
        }

        foreach (var lis in eventListenerDatas)
        {
            lis.Event += this;
            lis.Subscribe();
        }
    }

    public void Unsubscribe()
    {
        foreach (var lis in eventListenerDatas)
        {
            lis.Unsubscribe();
        }
    }
}