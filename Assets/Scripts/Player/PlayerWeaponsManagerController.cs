using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using CorruptCity.Entities.Weapons;
using CorruptCity.Entities.Spawn;
using CorruptCity.Variables;
using CorruptCity.General.Data;
using CorruptCity.General;

namespace CorruptCity.Entities.Player
{
    /*
    * Manage weapons on player
    */
    [RequireComponent(typeof(PlayerShootController))]
    public class PlayerWeaponsManagerController : MonoBehaviour
    {
        //Editor variables
        [Header("Variables")]
        [SerializeField] private Weapon[] weapons = null;
        [SerializeField] private ScriptablePlayerConfig scriptablePlayerConfig = null;
        [SerializeField] private WeaponVariable weaponVariable = null;
        [SerializeField] private WeaponProfile gunProfile = null;
        [SerializeField] private WeaponProfile rifleProfile = null;
        [SerializeField] private WeaponProfile machineGunProfile = null;
        [SerializeField] private WeaponProfile grenadeLauncherProfile = null;
        [SerializeField] private WeaponProfile RPGProfile = null;

        //Variables
        private SpawnController activeSpawnController = null;
        private PlayerShootController playerShootController = null;
        private Weapon currentActiveWeapon = null;
        //SET SINGLETON

        //Monobehaviour
        //Take references
        void Awake()
        {
            playerShootController = GetComponent<PlayerShootController>();
            SetDefaultWeapon();
        }

        //Methods
        //Set default weapon
        public void SetDefaultWeapon()
        {
            //Switch weapon cases
            switch (scriptablePlayerConfig.playerOfficer.weapon)
            {
                case EWeapon.Gun:
                    weaponVariable.Value = gunProfile;
                    break;
                case EWeapon.Rifle:
                    weaponVariable.Value = rifleProfile;
                    break;
                case EWeapon.MachineGun:
                    weaponVariable.Value = machineGunProfile;
                    break;
                case EWeapon.GrenadeLauncher:
                    weaponVariable.Value = grenadeLauncherProfile;
                    break;
                case EWeapon.RPG:
                    weaponVariable.Value = RPGProfile;
                    break;
            }

            SetWeapon(weaponVariable.Value);
        }
        //Set new weapon
        public void SetWeapon(WeaponProfile value)
        {
            //Itinerate weapons and search coincidences
            foreach (Weapon weapon in weapons)
            {
                //Check weapons
                bool canSetWeapon = !weapon.WeaponReference.activeInHierarchy && weapon.WeaponProfile == value;

                //Set values
                if (canSetWeapon)
                {
                    if (currentActiveWeapon != null)
                    {
                        currentActiveWeapon.IsActive = false;
                        currentActiveWeapon.WeaponReference.SetActive(false);
                    }

                    weapon.IsActive = canSetWeapon;
                    break;
                }
            }

            //Active weapon
            SetActiveWeapon();
        }
        //Set active weapon functional
        private void SetActiveWeapon()
        {
            //Itinerate weapons and set profile
            foreach (Weapon weapon in weapons)
            {
                //Check active weapon
                if (weapon.IsActive)
                {
                    currentActiveWeapon = weapon;
                    break;
                }
            }

            //Set values
            currentActiveWeapon.WeaponReference.SetActive(true);
            activeSpawnController = currentActiveWeapon.WeaponReference.GetComponent<SpawnController>();
            playerShootController.WeaponProfile = currentActiveWeapon.WeaponProfile;
            playerShootController.SpawnController = activeSpawnController;
        }
    }

    //Class used to store releation gameObject-profile
    [Serializable]
    public class Weapon
    {
        //Editor variables
        [Header("Variables")]
        [SerializeField] private GameObject weaponReference;
        [SerializeField] private WeaponProfile weaponProfile;
        [SerializeField] private bool isActive = false;

        //Attributes
        public GameObject WeaponReference { get => weaponReference; }
        public WeaponProfile WeaponProfile { get => weaponProfile; }
        public bool IsActive { get => isActive; set => isActive = value; }
    }
}