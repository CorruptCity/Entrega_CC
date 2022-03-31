using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace CorruptCity.Events
{
    /*
     * Components used to rise evets after a certain time
     */
    public class TimerController : MonoBehaviour
    {
        //Editor variables
#pragma warning disable IDE0044 // Add readonly modifier
        [SerializeField] private float timerDuration = 0f;
        [SerializeField] private bool unScaleTimer = false;
        [SerializeField] private UnityEvent timerEvent = null;
#pragma warning restore IDE0044 // Add readonly modifier

        //Variables
        private Coroutine timerLoop = null;
        private float currentTime = 0f;

        public float CurrentTime { get => currentTime; }

        //Monobehaviour
        //Stop coroutine
#pragma warning disable IDE0051 // Remove unused private members
        private void OnDisable()
#pragma warning restore IDE0051 // Remove unused private members
        {
            StopAllCoroutines();
            timerLoop = null;
        }

        //Methods
        //Call the loop if it isnt started
        public void StartTimer()
        {
            //Check if its running
            if(timerLoop == null)
                timerLoop = StartCoroutine(TimerLoop());
        }

        //Clean coroutine loop
        public void StopTimer()
        {
            StopAllCoroutines();
            timerLoop = null;
        }
        //Raise a event after a time
        private IEnumerator TimerLoop()
        {
            //Set time
            currentTime = timerDuration;

            //Loop timer
            do
            {
                //Timer type
                if (!unScaleTimer)
                    currentTime -= Time.deltaTime;
                else
                    currentTime -= Time.unscaledDeltaTime;

                yield return new WaitForEndOfFrame();

            } while (currentTime > 0);            

            timerLoop = null;      

            timerEvent?.Invoke();      
        }
    }
}