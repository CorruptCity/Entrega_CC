using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CorruptCity.Entities.Player;

namespace CorruptCity.Entities.Weapons
{
    /*
    * Store weapon information
    */
    [CreateAssetMenu(fileName = "New_Weapon_Profile", menuName = "Entities/Weapon_Profile")]
    public class WeaponProfile : ScriptableObject
    {
        //Editor variables
        [Header("Variables")]
        [SerializeField] private float fireRate = 0f;
        [SerializeField] private int ammoCharge = 0;
        [SerializeField] private int maxTotalAmmo = 0;
        [SerializeField] private float reloadTime = 0f;
        [SerializeField] private EShootMode shootMode = EShootMode.SingleShoot;

        //Attributes
        public EShootMode ShootMode { get => shootMode; }
        public float FireRate { get => fireRate; }
        public int AmmoCharge { get => ammoCharge; }
        public int MaxTotalAmmo { get => maxTotalAmmo; }
        public float ReloadTime { get => reloadTime; }
    }
}
