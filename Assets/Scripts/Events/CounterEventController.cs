using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace CorruptCity.Event
{
    /*
     * This component raise event after reaching a number
     */
    public class CounterEventController : MonoBehaviour
    {
        //Editor variables
        [Header("Variables")]
#pragma warning disable IDE0044 // Add readonly modifier
        [SerializeField] private int targetNumber = 0;
        [SerializeField] private UnityEvent raiseEventOnNumber = null;
#pragma warning restore IDE0044 // Add readonly modifier

        //Variables
        private int currentNumber = 0;

        //Methods
        //Sum to current number any value and raise event if its necessary
        public void NumberVariation(int value)
        {
            //Check value
            bool canRaise = currentNumber + value >= targetNumber;

            if (canRaise)
                raiseEventOnNumber?.Invoke();

            //Set value
            currentNumber += value;
        }

        //Reset current number value
        public void Reset() => currentNumber = 0;
    }
}