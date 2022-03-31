using System.Collections;
using System.Collections.Generic;
using CorruptCity.Tools;
using UnityEngine;
using UnityEngine.Events;

namespace CorruptCity.Entities.Health
{
    /*
    * Set a shield variation on player
    */
    [RequireComponent(typeof(Collider))]
    public class ShieldVariationController : MonoBehaviour
    {
        //Variables
        [Header("Variables")]
        [SerializeField] private int shieldVariationValue = 1;
        [SerializeField] private int[] layers = null;
        [SerializeField] private UnityEvent eventOnVariation = null;

        //Variables
        private bool canAddShield = true;

        //Monobehaviour
        //Take reference and set collidier values
        void Awake() => GetComponent<Collider>().isTrigger = true;
        //Enable/disable shield add
        void OnEnable() => canAddShield = true;
        void OnDisable() => canAddShield = false;

        //Apply shield variation
        void OnTriggerEnter(Collider other)
        {
            //Check if entity has shield controller
            if (CollectionTools.ContainsObject(layers, other.gameObject.layer)
            && other.TryGetComponent(out ShieldController shieldController)
            && canAddShield)
            {
                shieldController.AddShield(shieldVariationValue);
                eventOnVariation?.Invoke();
            }
        }
    }
}