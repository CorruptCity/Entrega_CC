using UnityEngine;

namespace CorruptCity.Entities
{
    /*
     * Makes a drop appear after certain calculations
     */
    public class DropManagerController : MonoBehaviour
    {
        //Editor variables
        [Header("Variables")]
        [Range(0, 100)]
#pragma warning disable IDE0044 // Add readonly modifier
        [SerializeField] private float dropPercent = 0f;
        [SerializeField] private ObjectToDrop[] objectToDrops = null;
#pragma warning restore IDE0044 // Add readonly modifier

        //Methods
        public void ReleaseDrop()
        {
            //Local method
            //Check if can drop
            static bool CanDrop(float percentResult, float totalPercent) => percentResult <= totalPercent;

            //Check if can drop           
            if (CanDrop(Random.Range(0, 100), dropPercent))
            {
                //Itinerate and search for drop
                foreach (ObjectToDrop objectToDrop in objectToDrops)
                {
                    //Check percent  
                    if(CanDrop(Random.Range(0, 100), objectToDrop.DropPercent))
                    {
                        GameObject newDrop = Instantiate(objectToDrop.DropPrefab);
                        newDrop.transform.position = transform.position;
                        break;
                    }
                }
            }
        }
    }
}