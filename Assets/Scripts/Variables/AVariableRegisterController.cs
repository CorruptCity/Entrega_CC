using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CorruptCity.Variables
{
    /*
     * Base class to register any type of variables
     * T = Scriptable variable type
     * T2 = Target component type
     */
    public abstract class AVariableRegisterController<T, T2> : MonoBehaviour where T : AScriptableVariable<T2> where T2 : Component
    {
        //Editor variables
        [Header("Variables")]
#pragma warning disable IDE0044 // Add readonly modifier
        [SerializeField] private T scriptableVariable = default;
#pragma warning restore IDE0044 // Add readonly modifier

        //Methods
        //Register variable reference
        public void RegisterVariable() => scriptableVariable.Value = GetComponent<T2>();
    }
}