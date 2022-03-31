using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CorruptCity.Scene
{
    /*
     * Store level information of lvl
     */
    [CreateAssetMenu(fileName ="New_Lvl_Config", menuName ="Scene/Lvl_Config")]
    public class LvlConfigurationProfile : ScriptableObject
    {
        //Editor variables
        [Header("Variables")]
#pragma warning disable IDE0044 // Agregar modificador de solo lectura
        [SerializeField] private int activeEnemies = 0;
        [SerializeField] private int activeSceneItems = 0;
        [SerializeField] private int activeCitizens = 0;
        [SerializeField] private int activeCars = 0;
        [SerializeField] private GameObject[] enemiesPrefabs = null;
        [SerializeField] private GameObject[] citizensPrefabs = null;
        [SerializeField] private GameObject[] carPrefabs = null;
        [SerializeField] private GameObject[] sceneItemsPrefabs = null;
#pragma warning restore IDE0044 // Agregar modificador de solo lectura
        //Atributes
        public int ActiveEnemies { get => activeEnemies; }
        public int ActiveSceneItems { get => activeSceneItems; }
        public GameObject[] EnemiesPrefabs { get => enemiesPrefabs; }
        public GameObject[] SceneItemsPrefabs { get => sceneItemsPrefabs; }
        public GameObject[] CitizensPrefabs { get => citizensPrefabs; }
        public GameObject[] CarPrefabs { get => carPrefabs; }
        public int ActiveCitizens { get => activeCitizens; }
        public int ActiveCars { get => activeCars; }
    }
}
