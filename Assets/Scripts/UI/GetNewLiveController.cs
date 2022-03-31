using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

namespace CorruptCity.UI
{
    //Display timer and add a new life to player after 3h of last life used
    public class GetNewLiveController : MonoBehaviour
    {
        //Editor variables
        [Header("Variables")]
        [SerializeField] private TextMeshProUGUI remainingLivesTMP = null;

        //Events
        public static event Action NewLiveEvent = null;

        //Variables
        private int hoursCount = 0,
        minutesCount = 0,
        secondsCount = 0;

        //MonoBehaviour
        void OnEnable() => Debug.LogWarning("Implement information of REMAINING TIME from server, dateDiff");

        void Update()
        {
            //TO IMPLEMENT
        }
    }
}