using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using CorruptCity.Entities.Agents.RuntimeSet;

namespace CorruptCity.General
{
    // * Class used to manage event when all targets are disabled.
    public class KillTargetsManagerController : MonoBehaviour
    {
        //Editor variables
        [Header("Variables")]
        [SerializeField] private UnityEvent onTargetsDisable = null;

        //Variables
        private bool allDisable = false;

        //MonoBehaviour
        //* Check every frame entities state
        void Update()
        {
            bool canRaiseEvent = !allDisable && KillTargetsRuntimeSetRegister.runtimeSet.Count <= 0;

            if (canRaiseEvent)
            {
                allDisable = true;
                onTargetsDisable?.Invoke();
            } else if (canRaiseEvent)
                allDisable = false;
        }
    }
}
