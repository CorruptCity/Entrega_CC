using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CorruptCity.Entities.Weapons;

namespace CorruptCity.Variables
{
    /*
    * Save global reference to a weapon profile
    */
    [CreateAssetMenu(fileName ="NEw_Weapon_Variable", menuName ="Variables/Weapon_Variable")]
    public class WeaponVariable : AScriptableVariable<WeaponProfile> { }
}