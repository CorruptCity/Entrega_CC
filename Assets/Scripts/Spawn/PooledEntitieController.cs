using UnityEngine;

namespace CorruptCity.Entities.Spawn
{
    /*
     * Component used to store reference of spawn and return entities to it
     */
    public class PooledEntitieController : MonoBehaviour
    {
        //Variables
        private SpawnController spawnController = null;
        public SpawnController SpawnController { set => spawnController = value; }
        //Methods
        //Set target pool to return
        public void ReturnToPool()
        {
            //Check reference
            if (spawnController != null)
                spawnController.ReturnEntities(this);
        }
    }
}
