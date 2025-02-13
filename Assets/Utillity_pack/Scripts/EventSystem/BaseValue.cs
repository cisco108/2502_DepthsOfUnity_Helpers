using UnityEngine;

namespace EventSystem
{
    [CreateAssetMenu(fileName = "Value", menuName = "Scriptables/Value", order = 0)]
    public abstract class BaseValue<T> : ScriptableObject
    {
        [SerializeField] private T value;

        public virtual T Value => value;
    }
}