using UnityEngine;

namespace EventSystem
{
    [CreateAssetMenu(fileName = "GenericValue", menuName = "Scripables/ScripableEvent/GenericData")]
    public class GenericValue : BaseValue<object>
    {
        public enum ValueType
        {
            Bool,
            Int
        }

        [SerializeField] private ValueType valueType = ValueType.Bool;
        [SerializeField] private bool boolVal;
        [SerializeField] private int intVal = 0;

        public override object Value
        {
            get
            {
                return valueType switch
                {
                    ValueType.Bool => boolVal,
                    ValueType.Int => intVal,
                    _ => null 
                };
            }
        }
    }
}
