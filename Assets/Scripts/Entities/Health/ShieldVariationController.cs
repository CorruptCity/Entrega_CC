using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CorruptCity.Tools;

namespace CorruptCity.Entities.Health
{
    /*
    *This component modify 
    */
    [RequireComponent(typeof(Collider))]
    public class ShieldItemController : MonoBehaviour
    {
        //Editor variables
        [Header("Variables")]
        [SerializeField] private int shieldAddValue = 1;
        [SerializeField] private int[] targetLayers = null;

        //Monobehaviour
        //Set collider settings
        void Awake() => GetComponent<Collider>().isTrigger = true;

        //Check layers and apply shield modification
        void OnTriggerEnter(Collider other)
        {
            //Check values           
            if (CollectionTools.ContainsObject(targetLayers, other.gameObject.layer)
                && other.TryGetComponent<ShieldController>(out ShieldController shieldController))
                shieldController.AddShield(shieldAddValue);
        }
    }
}
