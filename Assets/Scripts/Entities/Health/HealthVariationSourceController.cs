using CorruptCity.Maths;
using UnityEngine;
using CorruptCity.Tools;
using UnityEngine.Events;

namespace CorruptCity.Entities.Health
{
    /*
     * Component used to apply damage on entities with health
     */
    [RequireComponent(typeof(Collider))]
    [RequireComponent(typeof(Rigidbody))]
    public class HealthVariationSourceController : MonoBehaviour
    {
        //Editor variables
        [Header("Variables")]
#pragma warning disable IDE0044 // Add readonly modifier
        [SerializeField] private int variationValue = 0;
        [SerializeField] private EOperationType operationType = EOperationType.Sum;
        [SerializeField] private int[] targetLayers = null;
        [SerializeField] private bool isTrigger = false;
        [SerializeField] private UnityEvent variationResponseEvent = null;
#pragma warning restore IDE0044 // Add readonly modifier

        //Variables
        private bool canVariateHealth = true;

        //Monobehaviour
        //Set collider config
#pragma warning disable IDE0051 // Remove unused private members
        private void Awake() => GetComponent<Collider>().isTrigger = isTrigger;

        //Enable/disable variation
        void OnEnable() => canVariateHealth = true;
        void OnDisable() => canVariateHealth = false;
        
        //Response on collider detections
        private void OnCollisionEnter(Collision collision) => ApplyHealthOperation(collision.gameObject);       
        private void OnTriggerEnter(Collider other) => ApplyHealthOperation(other.gameObject);
#pragma warning restore IDE0051 // Remove unused private members

        //Methods
        //Apply health operation
        private void ApplyHealthOperation(GameObject interactionEntities)
        {
            
            //Check if can apply variation  
            if (CollectionTools.ContainsObject(targetLayers, interactionEntities.layer) &&
                interactionEntities.TryGetComponent(out HealthController healthController)
                && canVariateHealth)
            {
                //Check operation type and make it
                switch (operationType)
                {
                    case EOperationType.Sum:
                        healthController.SumHP(variationValue);
                        break;

                    case EOperationType.Rest:
                        healthController.RestHP(variationValue);
                        break;
                }

                variationResponseEvent?.Invoke();
            }
        }
    }
}
