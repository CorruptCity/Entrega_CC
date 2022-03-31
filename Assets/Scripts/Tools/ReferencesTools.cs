using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CorruptCity.Variables;

namespace CorruptCity.Tools.References
{
    /*
     * Generic tools releated to references
     */
    public static class ReferencesTools
    {
        //Check if a reference is null
        public static bool IsNullReference<T>(T reference) => reference == null;

        //Check reference of a scriptable variable
        public static bool IsNullScriptableVariableReference<T>(AScriptableVariable<T> scriptableVariable, out T reference) where T : Component
        {
            //Variables
            bool returnValue = false;
            reference = default;

            //Check reference
            if (!IsNullReference(scriptableVariable))
                if (!IsNullReference(scriptableVariable.Value))
                    reference = scriptableVariable.Value;
                else
                    returnValue = true;
            else
                returnValue = true;

            return returnValue;
        }
    }
}