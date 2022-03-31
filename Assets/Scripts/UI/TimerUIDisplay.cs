using CorruptCity.Events;
using System;
using TMPro;
using UnityEngine;

namespace CorruptCity.UI
{
    /*
     * Controller used to display on realtime gameplay timer
     */
    [RequireComponent(typeof(TimerController))]
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class TimerUIDisplay : MonoBehaviour
    {
        //Variables
        //References
        private TimerController timerController = null;
        private TextMeshProUGUI textMeshProUGUI = null;

        //Monobehaviour
#pragma warning disable IDE0051 // Quitar miembros privados no utilizados
        private void Awake()
#pragma warning restore IDE0051 // Quitar miembros privados no utilizados
        {
            //Take references
            timerController = GetComponent<TimerController>();
            textMeshProUGUI = GetComponent<TextMeshProUGUI>();
        }

        // Update is called once per frame, set text to timer count
#pragma warning disable IDE0051 // Quitar miembros privados no utilizados
        void Update()
#pragma warning restore IDE0051 // Quitar miembros privados no utilizados
        {
            //Set time format
            TimeSpan time = TimeSpan.FromSeconds(timerController.CurrentTime);
            
            //Set secondsCount
            string currentSeconds = time.Seconds >= 10 ? time.Seconds.ToString() : "0" + time.Seconds.ToString();

            textMeshProUGUI.text = time.Minutes.ToString() + ":" + currentSeconds;
        }
    }
}
