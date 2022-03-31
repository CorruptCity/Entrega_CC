using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace CorruptCity.Events
{
    /*
     * Component used on agents to shoot
     */

    public class ShootingLoopController : MonoBehaviour
    {
        //Editor variables
        [Header("Variables")]
#pragma warning disable IDE0044 // Add readonly modifier
        [SerializeField] private float fireRate = 0.25f;
        [SerializeField] private UnityEvent shootPlayerUnityEvent = null;
#pragma warning restore IDE0044 // Add readonly modifier

        //Variables
        bool isShooting = false;

        //Monobehaviour
        //Set shooting loop
#pragma warning disable IDE0051 // Remove unused private members       

        private void OnEnable() => StartCoroutine(ShootingLoop());

        private void OnDisable() => StopAllCoroutines();

#pragma warning restore IDE0051 // Remove unused private members

        //Methods
        //Start shooting loop
        public void StartShooting() => isShooting = true;
        //Stops shooting loop
        public void StopShooting() => isShooting = false;
        //Shooting loop
        private IEnumerator ShootingLoop()
        {
            while (true)
            {
                yield return new WaitUntil(() => isShooting);
                shootPlayerUnityEvent?.Invoke();
                yield return new WaitForSeconds(fireRate);
            }
        }
    }
}