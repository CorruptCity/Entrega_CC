using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CorruptCity.Entities.Health;

namespace CorruptCity.Variables{
    /*
    * Set variable value 
    */
    [RequireComponent(typeof(ShieldController))]
    public class ShieldRegisterController : AVariableRegisterController<ShieldVariable, ShieldController>{}
}
