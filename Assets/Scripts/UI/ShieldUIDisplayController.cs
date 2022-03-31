using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Michsky.UI.ModernUIPack;
using CorruptCity.Variables;

namespace CorruptCity.UI
{
    /*
    * Display shield information on UI
    */
    [RequireComponent(typeof(ProgressBar))]
    public class ShieldUIDisplayController : MonoBehaviour
    {
        //Editor variables
        [Header("Variables")]
        [SerializeField] private ShieldVariable shieldVariable = null;

        //Variables
        private ProgressBar progressBar = null;

        //Monobehaviour
        //Take references
        void Awake() => progressBar = GetComponent<ProgressBar>();
        //Keep shield variable percent updated
        void Update()
        {
            int currentPercent = shieldVariable.Value.CurrentShield * 100 / shieldVariable.Value.MaxShield;            

            progressBar.ChangeValue(currentPercent);
        }
    }
}