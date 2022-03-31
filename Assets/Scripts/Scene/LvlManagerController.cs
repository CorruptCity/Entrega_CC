using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CorruptCity.Entities.Spawn;

namespace CorruptCity.Scene
{
    /*
     * Manage level distribution of entities
     */
    public class LvlManagerController : MonoBehaviour
    {
        //Editor variables
        [Header("Variables")]
#pragma warning disable IDE0044 // Agregar modificador de solo lectura
        [SerializeField] private LvlConfigurationProfile lvlConfigProfile = null;
        [SerializeField] private SpawnController enemiesSpawn = null;
        [SerializeField] private SpawnController citizensSpawn = null;
        [SerializeField] private SpawnController carsSpawn = null;
        [SerializeField] private SpawnController itemsSpawn = null;
#pragma warning restore IDE0044 // Agregar modificador de solo lectura


        //Monobehaviour
        //Set spawn configurations
#pragma warning disable IDE0051 // Quitar miembros privados no utilizados
        private void Awake()
#pragma warning restore IDE0051 // Quitar miembros privados no utilizados
        {
            //Local methods
            //Set spawn config
            static void SetSpawnConfig(SpawnController spawnController, GameObject[] randomPrefabs)
            {
                spawnController.IsRandomPrefab = true;
                spawnController.RandomPrefabs = randomPrefabs;
            }

            //Set enemies spawn
            SetSpawnConfig(enemiesSpawn, lvlConfigProfile.EnemiesPrefabs);
            //Set citizens spawn
            SetSpawnConfig(citizensSpawn, lvlConfigProfile.CitizensPrefabs);
            //Set car spawn
            SetSpawnConfig(carsSpawn, lvlConfigProfile.CarPrefabs);
            //Set item spawn
            SetSpawnConfig(itemsSpawn, lvlConfigProfile.SceneItemsPrefabs);
        }

        //Keep level entities updated
#pragma warning disable IDE0051 // Quitar miembros privados no utilizados
        private void Update()
#pragma warning restore IDE0051 // Quitar miembros privados no utilizados
        {
            //Local methods
            //Spawn entities if required number is lower
            static void KeepSpawn(SpawnController spawnController, int activeEntities)
            {
                //Check current number and target number
                bool mustSpawn = activeEntities < spawnController.ActiveEntities;

                //Spawn
                if (mustSpawn)
                    spawnController.SpawnEntities();
            }

            //Body
            //Keep enemies
            KeepSpawn(enemiesSpawn, lvlConfigProfile.ActiveEnemies);
            //Keep citizens
            KeepSpawn(citizensSpawn, lvlConfigProfile.ActiveCitizens);
            //Keep cars
            KeepSpawn(carsSpawn, lvlConfigProfile.ActiveCars);
            //Keep items
            KeepSpawn(itemsSpawn, lvlConfigProfile.ActiveSceneItems);
        }
    }
}