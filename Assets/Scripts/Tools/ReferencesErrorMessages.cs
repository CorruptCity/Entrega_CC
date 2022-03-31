using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CorruptCity.Tools.References
{
    /*
     * Static class used to debug generic error messages releated to references
     */
    public static class ReferencesErrorMessages
    {
        //Debug error, reference is missing
        public static void DebugErrorMissingReference(string componentName, string gameObjectName, string referenceName) => 
            Debug.LogError("Error: Reference " +referenceName+ " is missing on game object " +gameObjectName+ ", with component " +componentName+".");
    }
}