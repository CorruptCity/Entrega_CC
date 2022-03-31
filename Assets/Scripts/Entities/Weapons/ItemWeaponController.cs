using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using CorruptCity.Entities.Weapons;
using CorruptCity.Entities.Player;

namespace CorruptCity.Entities.Weapons
{
    /*
    * Set a new weapon to player 
    */
    [RequireComponent(typeof(Collider))]
    public class ItemWeaponController : MonoBehaviour
    {
        //Editor variables
        [Header("Variables")]
        [SerializeField] private int playerLayer = 3;
        [SerializeField] private WeaponProfile weaponProfile = null;
        [SerializeField] private UnityEvent eventOnWeaponChange = null;

        //Variables
        private bool canUseItem = true;

        //Monobehaviour
        //Set collider
        void Awake() => GetComponent<Collider>().isTrigger = true;

        //Enable or disable item
        void OnEnable() => canUseItem = true;
        void OnDisable() => canUseItem = false;

        void OnTriggerEnter(Collider other)
        {
            //Check conditions
            bool canRaise = other.gameObject.layer.Equals(playerLayer)
            && canUseItem;

            //Check layer on trigger
            if (canRaise && other.TryGetComponent(out PlayerWeaponsManagerController playerWeaponsManagerController))
            {
                //USE SINGLETON AND SET METHOD TO MAKE IT TEMPORAL
                eventOnWeaponChange?.Invoke();
                playerWeaponsManagerController.SetWeapon(weaponProfile);
            }
        }
    }
}
