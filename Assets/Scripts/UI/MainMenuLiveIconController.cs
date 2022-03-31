using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CorruptCity.General;
using UnityEngine.Events;

namespace CorruptCity.UI
{
    //Raise event on target  live
    public class MainMenuLiveIconController : MonoBehaviour
    {
        //Editor variables
        [Header("Variables")]
        [SerializeField] private int targetLive = 0;
        [SerializeField] private ScriptablePlayerConfig scriptablePlayerConfig = null;
        [SerializeField] private UnityEvent liveResponseEvent = null;
        [SerializeField] private UnityEvent outLiveResponseEvent = null;

        //Variables
        private bool hasLive = false;

        //MonoBehaviour
        //Subscribe and check response
        void OnEnable()
        {
            CheckResponse();
            GetNewLiveController.NewLiveEvent += CheckResponse;
        }
        //Unsubscribe 
        void OnDisable() => GetNewLiveController.NewLiveEvent -= CheckResponse;

        //Methods
        //Check if must respond to current live amount
        private void CheckResponse()
        {
            bool hasEnoughsLive = targetLive <= scriptablePlayerConfig.playerCurrentLives;

            if (hasEnoughsLive && !hasLive)
            {
                hasLive = true;
                liveResponseEvent?.Invoke();
            }
            else if (!hasEnoughsLive && hasLive)
            {
                hasLive = false;
                outLiveResponseEvent?.Invoke();
            }
        }
    }
}