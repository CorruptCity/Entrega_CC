using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace CorruptCity.General.Data
{
    //Class used to store vehicle information
    [Serializable]
    public class Vehicle
    {
        public EVehicleType vehicleType = EVehicleType.Car;
        public float lifeMultiplier = 1;
        public float movementSpeedMultiplier = 1;
    }
}