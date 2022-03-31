using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CorruptCity.Variables;
using CorruptCity.Tools.References;

namespace CorruptCity.Entities.Movement
{
    /*
     * Controller used to share transform values
     */
    public class ShareTransformController : MonoBehaviour
    {
        //Editor variables
        [Header("Variables")]
#pragma warning disable IDE0044 // Add readonly modifier
        [SerializeField] private bool x = false;
        [SerializeField] private bool y = false;
        [SerializeField] private bool z = false;
        [SerializeField] private Transform transformToShare = null;
        [SerializeField] private ScriptableTransformVariable scriptableTransformVariable = null;
#pragma warning restore IDE0044 // Add readonly modifier

        //Monobehaviour   
        // Update is called once per frame
#pragma warning disable IDE0051 // Remove unused private members
        void Update()
#pragma warning restore IDE0051 // Remove unused private members
        {
            Transform targetTransform = transformToShare ? transformToShare 
            : !ReferencesTools.IsNullScriptableVariableReference(scriptableTransformVariable, out Transform variableTransform) ? variableTransform : null;
            
            //Share position
            if(targetTransform != null)
            {
                float xValue = x ? targetTransform.position.x : transform.position.x,
                    yValue = y ? targetTransform.position.y : transform.position.y,
                    zValue = z ? targetTransform.position.z : transform.position.z;

                transform.position = new Vector3(xValue, yValue, zValue);
            }
        }
    }

}