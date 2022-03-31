using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CorruptCity.Entities.Health;

namespace CorruptCity.Variables
{
    /*
    * Save shield reference
    */
    [CreateAssetMenu(fileName ="New_Shield_Variable", menuName ="Variables/Shield_Controller")]
    public class ShieldVariable : AScriptableVariable<ShieldController> { }
}