using CorruptCity.Variables;
using Michsky.UI.ModernUIPack;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CorruptCity.Tools.References;
using CorruptCity.Entities.Health;

namespace CorruptCity.UI
{
    /*
     * Controller used to manage hearts animations based on player life
     */
    [RequireComponent(typeof(AnimatedIconHandler))]
    //[RequireComponent()]
    public class HeartUIController : MonoBehaviour
    {
        //Editor variables
        [Header("Variables")]
#pragma warning disable IDE0044 // Add readonly modifier
        [SerializeField] private int targetHealth = 0;
        [SerializeField] private ScriptableHealthVariable playerHealthVariable = null;
#pragma warning restore IDE0044 // Add readonly modifier

        //Variables
        bool isOut = true;
        private AnimatedIconHandler animatedIconHandler = null;

        //Monobehaviour
        //Take references
#pragma warning disable IDE0051 // Remove unused private members
        private void Awake() => animatedIconHandler = GetComponent<AnimatedIconHandler>();
#pragma warning restore IDE0051 // Remove unused private members
        //Check health and raise or not animation
#pragma warning disable IDE0051 // Remove unused private members
        private void Update()
#pragma warning restore IDE0051 // Remove unused private members
        {
            //Check referenc
            if(!ReferencesTools.IsNullScriptableVariableReference(playerHealthVariable, out HealthController playerHealthController))
            {
                //Check cases
                bool goInAnimation = playerHealthController.CurrentHealth >= targetHealth && isOut,
                    goOutAnimation = playerHealthController.CurrentHealth < targetHealth && !isOut;

                if (goInAnimation)
                {
                    isOut = false;
                    animatedIconHandler.PlayIn();
                }
                else if (goOutAnimation)
                {
                    isOut = true;
                    animatedIconHandler.PlayOut();
                }
            }
        }
    }
}