using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace CorruptCity.General.Data
{
    [Serializable]
    public class Officer
    {
        //Variables
        public int BadgeNumber = 0;
        public EOfficerRange officerRange = EOfficerRange.Officer;
        public EWeapon weapon = EWeapon.Gun;
        public float lifeMultiplier = 1;
        public float movementSpeedMultiplier = 1;
    }
}