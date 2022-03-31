using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using static UnityEngine.InputSystem.InputAction;
using CorruptCity.Entities.Weapons;
using CorruptCity.Entities.Spawn;

namespace CorruptCity.Entities.Player
{
    /*
     * Component used to shoot 
     */
    public class PlayerShootController : MonoBehaviour
    {
        //Editor variables
        [Header("Variables")]
#pragma warning disable IDE0044 // Add readonly modifier
        [SerializeField] private UnityEvent singleShootEvent = null;
        [SerializeField] private UnityEvent automaticShootEvent = null;
        [SerializeField] private UnityEvent reloadEvent = null;
#pragma warning restore IDE0044 // Add readonly modifier
        //Variables
        private int currentAmmoCharge = 0,
        currentTotalAmmo = 0;
        private WeaponProfile weaponProfile = null;
        private PlayerInputActions playerActions = null;
        private SpawnController spawnController = null;
        private bool canShoot = true,
            isClickPressing = false;
            public static PlayerShootController instance = null;

        //Attributes
        public WeaponProfile WeaponProfile
        {
            set
            {
                weaponProfile = value;
                SetNewWeapon(value);
            }
        }
        public int CurrentAmmoCharge { get => currentAmmoCharge; }
        public int CurrentTotalAmmo { get => currentTotalAmmo; }
        public SpawnController SpawnController { set => spawnController = value; }

        //Monobehaviour
#pragma warning disable IDE0051 // Remove unused private members
        private void Awake()
#pragma warning restore IDE0051 // Remove unused private members
        {
            //Set input
            playerActions = new PlayerInputActions();
            playerActions.MouseActions.Enable();
            instance = this;
        }

        //Subscribe to action event
#pragma warning disable IDE0051 // Remove unused private members
        private void OnEnable()
        {
            playerActions.MouseActions.LeftClick.started += Shoot;
            playerActions.MouseActions.LeftClick.canceled += (callbackContext) => { isClickPressing = false; };
        }
#pragma warning restore IDE0051 // Remove unused private members

        //Unsubscribe to action event
#pragma warning disable IDE0051 // Remove unused private members
        private void OnDisable()
        {
            playerActions.MouseActions.LeftClick.started -= Shoot;
            playerActions.MouseActions.LeftClick.canceled -= (callbackContext) => { isClickPressing = false; };

            StopAllCoroutines();
        }
#pragma warning restore IDE0051 // Remove unused private members

        //Methods
        //Set weapon profile values on local variables
        private void SetNewWeapon(WeaponProfile weaponProfile)
        {
            currentAmmoCharge = weaponProfile.AmmoCharge;
            currentTotalAmmo = weaponProfile.MaxTotalAmmo;
            canShoot = true;
        }
        //Disable shoot and wait until reload
        private IEnumerator ReloadDelay()
        {
            reloadEvent?.Invoke();
            yield return new WaitForSeconds(weaponProfile.ReloadTime);
            //Set ammo
            if (currentTotalAmmo - weaponProfile.AmmoCharge >= 0)
            {
                currentAmmoCharge = weaponProfile.AmmoCharge;
                currentTotalAmmo = currentTotalAmmo - weaponProfile.AmmoCharge;
            }
            else if (currentAmmoCharge - weaponProfile.AmmoCharge < 0)
            {
                currentAmmoCharge = weaponProfile.AmmoCharge - (weaponProfile.AmmoCharge - currentAmmoCharge);
                currentTotalAmmo = 0;
            }


            canShoot = true;
        }

        //Used to raise shoot events on input ON
        public void Shoot(CallbackContext callbackContext)
        {
            //Check can shoot
            if (canShoot)
            {
                canShoot = false;

                //Check shoot mode
                switch (weaponProfile.ShootMode)
                {
                    case EShootMode.SingleShoot:
                        StartCoroutine(SingleShootWait());
                        break;

                    case EShootMode.AutoShoot:
                        if (!isClickPressing)
                        {
                            isClickPressing = true;
                            StartCoroutine(AutomaticShootLoop());
                        }
                        break;
                }
            }
        }

        //Wait until can shoot again
        private IEnumerator SingleShootWait()
        {
            if (currentAmmoCharge > 0)
            {
                currentAmmoCharge--;
                singleShootEvent?.Invoke();
                spawnController.SpawnEntities();
                yield return new WaitForSeconds(weaponProfile.FireRate);

                canShoot = true;
            }
            else
                StartCoroutine(ReloadDelay());
        }

        //Loop shoot event
        private IEnumerator AutomaticShootLoop()
        {
            do
            {
                if (currentAmmoCharge > 0)
                {
                    currentAmmoCharge--;
                    automaticShootEvent?.Invoke();
                    spawnController.SpawnEntities();
                    yield return new WaitForSeconds(weaponProfile.FireRate);
                }
                else
                    isClickPressing = false;

            } while (isClickPressing);

            if (currentAmmoCharge > 0)
                canShoot = true;
            else
                StartCoroutine(ReloadDelay());
        }
    }
}
