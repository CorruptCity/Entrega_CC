using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CorruptCity.Entities.Spawn;
using CorruptCity.General.Data;
using CorruptCity.General;

namespace CorruptCity.Entities.Player
{
    public class PlayerSpawnCarManagerController : MonoBehaviour
    {
        //Editor variables
        [Header("Variables")]
        [SerializeField] private SpawnController policeCarSpawnController = null;
        [SerializeField] private SpawnController swatCarSpawnController = null;
        [SerializeField] private SpawnController tankSpawnSpawnController = null;
        [SerializeField] private ScriptablePlayerConfig scriptablePlayerConfig = null;

        //MonoBehaviour
        //Check type of car to spawn and set it
        void OnEnable()
        {
            //To use spawnController
            SpawnController spawnController = null;
            //Local method
            //Set spawn controller to use
            void SetSpawnController()
            {
                //Check vehicle type
                switch (scriptablePlayerConfig.playerVehicle.vehicleType)
                {
                    case EVehicleType.Car:
                        spawnController = policeCarSpawnController;
                        break;
                    case EVehicleType.Swat:
                        spawnController = swatCarSpawnController;
                        break;
                    case EVehicleType.Tank:
                        spawnController = tankSpawnSpawnController;
                        break;
                }
            }

            //Execution code
            SetSpawnController();
            spawnController.SpawnEntities();
        }
    }
}