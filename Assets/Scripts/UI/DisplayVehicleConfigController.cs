using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CorruptCity.General;
using TMPro;
using CorruptCity.Tools.References;
using CorruptCity.General.Data;

namespace CorruptCity.UI
{
    //Controller used to display vehicle configuration
    public class DisplayVehicleConfigController : MonoBehaviour
    {
        //Editor variables
        [Header("Variables")]
        [SerializeField] private ScriptablePlayerConfig scriptablePlayerConfig = null;
        [SerializeField] private Image displayImage = null;
        [SerializeField] private TextMeshProUGUI groupTMP = null;
        [SerializeField] private TextMeshProUGUI vehicleTMP = null;
        [SerializeField] private TextMeshProUGUI weaponTMP = null;
        [SerializeField] private TextMeshProUGUI lifeTMP = null;
        [SerializeField] private TextMeshProUGUI speedTMP = null;

        //Variables
        private const string GROUP_PREFIX = " Group: ",
        VEHICLE_PREFIX = " Vehicle: ",
        WEAPON_PREFIX = " Weapon: ",
        LIFE_PREFIX = " Life: x",
        SPEED_PREFIX = " Speed: x";

        //MonoBehaviour
        //Keep update all the information to display
        void Update()
        {
            #region Avoid errors of missing references
            if (!ReferencesTools.IsNullReference(scriptablePlayerConfig))
            {
                //Vehicle to display
                Vehicle vehicle = scriptablePlayerConfig.playerVehicle;

                EVehicleType vehicleType = scriptablePlayerConfig.playerVehicle.vehicleType;

                displayImage.sprite = scriptablePlayerConfig.vehicleImage;

                if (!ReferencesTools.IsNullReference(groupTMP))
                    groupTMP.text = GROUP_PREFIX + "Temporal group";

                //Local methods
                //Get vehicle name
                string VehicleName(EVehicleType vehicleType)
                {
                    string result = string.Empty;

                    //Switch vehicle type
                    switch (vehicleType)
                    {
                        case EVehicleType.Car:
                            result = "Police car";
                            break;
                        case EVehicleType.Swat:
                            result = "Armored car";
                            break;
                        case EVehicleType.Tank:
                            result = "Tank";
                            break;
                    }

                    return result;
                }
                     
                if (!ReferencesTools.IsNullReference(vehicleTMP))
                    vehicleTMP.text = GROUP_PREFIX + VehicleName(vehicleType);

                //Local method
                //Get weapon name
                string WeaponName(EVehicleType vehicleType)
                {
                    string result = string.Empty;

                    //Switch vehicle type
                    switch (vehicleType)
                    {
                        case EVehicleType.Car:
                            result = "Gun";
                            break;
                        case EVehicleType.Swat:
                            result = "Machine gun";
                            break;
                        case EVehicleType.Tank:
                            result = "RPG";
                            break;
                    }

                    return result;
                }

                if (!ReferencesTools.IsNullReference(weaponTMP))
                    weaponTMP.text = WEAPON_PREFIX + WeaponName(vehicleType);

                if (!ReferencesTools.IsNullReference(lifeTMP))
                    lifeTMP.text = LIFE_PREFIX + vehicle.lifeMultiplier.ToString();

                if (!ReferencesTools.IsNullReference(speedTMP))
                    speedTMP.text = SPEED_PREFIX + vehicle.movementSpeedMultiplier.ToString();
            }
            #endregion
        }
    }
}