using CorruptCity.Tools;
using UnityEngine;

namespace CorruptCity.Events
{
    /*
     * Class used as base of collider base components
     */
    [RequireComponent(typeof(Collider))]
    [RequireComponent(typeof(Rigidbody))]
    public abstract class AColliderEventTrigger : MonoBehaviour
    {
        //Variables
        private bool canDetect = true;

        //MonoBehaviour
        //Implementation used to enable and disable detections
        void OnEnable() { }
        void OnDisable() { }
        //Methods
        //Allow or not detections
        public void AllowDetections(bool value) => canDetect = value;

        //Check layer coincidences and raise related event responses
        protected void CheckResponses(LayersResponse[] layersResponses, int targetLayer)
        {
            //Check if can detect
            if (canDetect)
            {
                //Itinerate responses
                foreach (LayersResponse layersResponse in layersResponses)
                    if (CollectionTools.ContainsObject(layersResponse.TargetLayers, targetLayer))
                        layersResponse.ResponseUnityEvent?.Invoke();
            }
        }
    }
}
