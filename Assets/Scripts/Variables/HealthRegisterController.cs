using CorruptCity.Entities.Health;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CorruptCity.Variables
{
    /*
     * Component used to register health references
     */
    public class HealthRegisterController : AVariableRegisterController<ScriptableHealthVariable, HealthController> { }
}