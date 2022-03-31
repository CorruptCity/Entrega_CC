using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CorruptCity.Entities.Weapons;
using CorruptCity.General;

namespace CorruptCity.Entities.Agents
{
    //Global player configuration
    public static class PlayerConfig
    {
        //Variables
        public static ScriptableEnum playerCharacter = null;
        public static WeaponProfile defaultPlayerWeaponProfile = null;
        public static CarProfile carProfile = null;
    }
}