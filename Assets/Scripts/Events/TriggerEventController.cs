using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace CorruptCity.Events
{
    /*
    *Component used to trigger event con trigger calls
    */
    public class TriggerEventController : MonoBehaviour
    {
        //Editor variables
        [Header("Variables")]
        [SerializeField] private int[] onTriggerEnterLayers = null;
        [SerializeField] private GameObject[] targetGameobjects = null;
        [SerializeField] private UnityEvent onTriggerEvent = null;
        [SerializeField] private UnityEvent onTriggerExit = null;

        //Monobehaviour
        //Check enter layers and raise events
        public void OnTriggerEnter(Collider other)
        {
            //Check layer and entity
            if (CheckLayers(other.gameObject.layer) && IsTargetGameobject(other.gameObject))
                onTriggerEvent?.Invoke();
        }
        //Check enter layers and raise events
        void OnTriggerExit(Collider other)
        {
            //Check layer and entity
            if (CheckLayers(other.gameObject.layer) && IsTargetGameobject(other.gameObject))
                onTriggerExit?.Invoke();
        }
        //Methods
        //Check if collider is on targetGameobjects list
        bool IsTargetGameobject(GameObject entity)
        {
            bool result = targetGameobjects.Length > 0 ? false : true;

            //Itinerate target game objects
            if (!result)
                foreach (GameObject target in targetGameobjects)
                {
                    if (target.Equals(entity))
                    {
                        result = true;
                        break;
                    }
                }

            return result;
        }

        //Check if entities has correct layer
        private bool CheckLayers(int entitiesLayer)
        {
            bool hasLayer = false;

            //Itinerate layers
            foreach (int layer in onTriggerEnterLayers)
            {
                if (layer.Equals(entitiesLayer))
                {
                    hasLayer = true;
                    break;
                }
            }

            return hasLayer;
        }
    }
}
