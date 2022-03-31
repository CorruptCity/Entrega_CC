using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace CorruptCity.Entities.Spawn
{
    /*
     * Controller used to spawn on an optimized way entities
     */
    public class SpawnController : MonoBehaviour
    {
        //Editor variables
        [Header("Spawn variables")]
#pragma warning disable IDE0044 // Add readonly modifier
        [SerializeField] private GameObject entitiesPrefab = null;
        [SerializeField] private bool isRandomPrefab = false;
        [SerializeField] private GameObject[] randomPrefabs = null;
        [SerializeField] private int expectedPoolsize = 0;
        [SerializeField] private bool maxEntities = false;
        [SerializeField] private Transform spawnPoint = null;
        [SerializeField] private Transform[] randomSpawnPoints = null;
        [SerializeField] private bool isRandomSpawn = false;
        [SerializeField] private UnityEvent eventOnSpawn = null;
#pragma warning restore IDE0044 // Add readonly modifier
        //Variables
        //Store all the pooled entities to spawn it
#pragma warning disable IDE0090 // Use 'new(...)'
        public readonly Queue<PooledEntitieController> pooledEntitiesQueue = new Queue<PooledEntitieController>();
#pragma warning restore IDE0090 // Use 'new(...)'
        //Information data
        private int entitiesCount = 0;

        //Attributes
        //Get Queue count
        public int ActiveEntities { get => pooledEntitiesQueue.Count; }
        public GameObject[] RandomPrefabs { set => randomPrefabs = value; }
        public bool IsRandomPrefab { set => isRandomPrefab = value; }

        //Monobehaviour
        // Start is called before the first frame update
#pragma warning disable IDE0051 // Remove unused private members
        void Start()
#pragma warning restore IDE0051 // Remove unused private members
        {
            //Instantiate all entities
            while (pooledEntitiesQueue.Count < expectedPoolsize)
                InstantiateEntities();
        }

        //Methods
        //Create a new entities from prefab and add it to list
        private PooledEntitieController InstantiateEntities()
        {
            //Return value
            PooledEntitieController pooledEntitieController = null;

            //Set new entities
            GameObject tempEntities = isRandomPrefab ? Instantiate(randomPrefabs[Random.Range(0, randomPrefabs.Length - 1)]) : Instantiate(entitiesPrefab);
            tempEntities.SetActive(false);

            //Store component
            //Try to get component and add it if its necessary
            pooledEntitieController = tempEntities.TryGetComponent(out PooledEntitieController tempPoolEntitieController)
                ? tempPoolEntitieController
                : tempEntities.AddComponent<PooledEntitieController>();

            //Set spawn transform and list reference
            SetTransform(pooledEntitieController);
            pooledEntitieController.SpawnController = this;
            pooledEntitiesQueue.Enqueue(pooledEntitieController);

            entitiesCount++;

            return pooledEntitieController;
        }

        //Set transform values
        private void SetTransform(PooledEntitieController pooledEntitieController)
        {
            //Transform to use
            Transform targetTransform = isRandomSpawn ? randomSpawnPoints[Random.Range(0, randomSpawnPoints.Length - 1)] : spawnPoint;

            //Set spawn transform
            pooledEntitieController.transform.position = targetTransform.position;
            pooledEntitieController.transform.rotation = targetTransform.rotation;
        }

        //Return to queue or destroy if limit has been reached
        public void ReturnEntities(PooledEntitieController pooledEntitieController)
        {
            //Check if spawned entities count has reach limit
            if (!pooledEntitiesQueue.Contains(pooledEntitieController))
            {
                pooledEntitieController.gameObject.SetActive(false);
                pooledEntitiesQueue.Enqueue(pooledEntitieController);
            }
        }

        //Set entities on world space
        public void SpawnEntities()
        {
            //Check if can spawn
            if (CanSpawn())
            {
                //Check if can instantiate new entities
                bool canInstantiate = pooledEntitiesQueue.Count <= 0 && !maxEntities
                || pooledEntitiesQueue.Count <= 0 && maxEntities && entitiesCount < expectedPoolsize;

                //Generate entities before 0 is reached, to have one ready
                if (canInstantiate)
                    InstantiateEntities();

                //Check queue has entities
                if (pooledEntitiesQueue.Count > 0)
                {
                    //Get entities and set values
                    PooledEntitieController spawnEntities = pooledEntitiesQueue.Dequeue();

                    SetTransform(spawnEntities);
                    spawnEntities.gameObject.SetActive(true);
                    eventOnSpawn?.Invoke();
                }
            }
        }

        //Check can spawn
        public bool CanSpawn()
        {
            bool canSpawn = false;

            //Itinerate if its necessary
            if (isRandomSpawn)
                foreach (Transform tempTransform in randomSpawnPoints)
                {
                    if (tempTransform.gameObject.activeInHierarchy)
                    {
                        canSpawn = true;
                        break;
                    }
                }
            //Manage maximum amount of entities
            else if (maxEntities)
            {
                int activeEntities = 0;

                //Itinerate and plus entities 
                foreach (var item in pooledEntitiesQueue)
                {
                    if (item.gameObject.activeInHierarchy)
                        activeEntities++;
                }

                if (activeEntities < expectedPoolsize)
                    canSpawn = true;
            }
            else
                canSpawn = true;


            return canSpawn;
        }
    }
}