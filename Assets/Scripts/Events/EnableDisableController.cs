using UnityEngine;
using UnityEngine.Events;

namespace CorruptCity.Events
{
    /*
     * Component use to rise events on enable or disable monobehaviour states
     */
    public class EnableDisableController : MonoBehaviour
    {
        //Editor variables
        [Header("State events")]
#pragma warning disable IDE0044 // Add readonly modifier
        [SerializeField] private UnityEvent enableUnityEvent = null;
        [SerializeField] private UnityEvent disableUnityEvent = null;
#pragma warning restore IDE0044 // Add readonly modifier

        //Monobehaviour
        //Raise events on each state
#pragma warning disable IDE0051 // Remove unused private members
        private void OnEnable() => enableUnityEvent?.Invoke();
        private void OnDisable() => disableUnityEvent?.Invoke();
#pragma warning restore IDE0051 // Remove unused private members
    }
}
