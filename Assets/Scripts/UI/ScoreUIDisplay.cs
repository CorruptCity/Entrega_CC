using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using CorruptCity.Entities.Agents;

namespace CorruptCity.UI
{
    /*
     * Display current global score
     */
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class ScoreUIDisplay : MonoBehaviour
    {
        //Variables
        private TextMeshProUGUI textMeshProUGUI = null;

        //Monobehaviour
        //Take references
#pragma warning disable IDE0051 // Quitar miembros privados no utilizados
        private void Awake() => textMeshProUGUI = GetComponent<TextMeshProUGUI>();
#pragma warning restore IDE0051 // Quitar miembros privados no utilizados

        // Update is called once per frame
#pragma warning disable IDE0051 // Quitar miembros privados no utilizados
        void Update() => textMeshProUGUI.text = ScoreSourceController.CurrentGlobalScore.ToString();
#pragma warning restore IDE0051 // Quitar miembros privados no utilizados
    }
}