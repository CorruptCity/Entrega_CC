using CorruptCity.Entities.Health;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CorruptCity.Variables
{
    /*
     * Variable used to store references of health variables
     */
    [CreateAssetMenu(fileName ="New_Health_variable", menuName ="Variables/Health_Variable")]
    public class ScriptableHealthVariable : AScriptableVariable<HealthController> { }
}