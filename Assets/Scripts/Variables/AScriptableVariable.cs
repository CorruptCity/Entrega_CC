using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CorruptCity.Variables
{
    /*
     * Base class for scriptable variables
     */
    public abstract class AScriptableVariable<T> : ScriptableObject
    {
        //Editor variables
        [Header("Variables")]
        [SerializeField] private T value = default;

        //Atributes
        public T Value { get => value; set => this.value = value; }
    }
}
