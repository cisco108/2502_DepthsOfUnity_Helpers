using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace EventSystem
{
    public interface IDataEvent
    {
        void AddListener(IDataEventListener listener);
        void RemoveListener(IDataEventListener listener);
        void Invoke(object data);
    }

    [CreateAssetMenu(fileName = "ScriptableDataEvent", menuName = "Scriptables/ScriptableDataEvent")]
    public class ScriptableDataEvent : ScriptableObject, IDataEvent
    {
        [SerializeField] private GenericValue data;
        [SerializeReference] private List<IDataEventListener> listeners = new();
        public IEnumerable<IDataEventListener> Listeners => listeners;

        public void AddListener(IDataEventListener listener)
        {
            listeners.Add(listener);
        }

        public void RemoveListener(IDataEventListener listener)
        {
            listeners.Remove(listener);
        }

        public static ScriptableDataEvent operator +(ScriptableDataEvent instance, IDataEventListener listener)
        {
            instance.AddListener(listener);
            return instance;
        }

        public static ScriptableDataEvent operator -(ScriptableDataEvent instance, IDataEventListener listener)
        {
            instance.RemoveListener(listener);
            return instance;
        }

        public void Invoke(object data)
        {
            foreach (var lis in listeners)
            {
                lis.OnInvoke();
            }
        }
    }

    public interface IDataEventListener
    {
        void OnInvoke();
    }
}