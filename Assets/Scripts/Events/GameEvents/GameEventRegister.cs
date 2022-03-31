using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace CorruptCity.Event
{
    //Register on game event and set responses from editor 
    public class GameEventRegister : MonoBehaviour
    {
        //Editor variables
        [Header("Event reference")]
        [SerializeField] private GameEvent gameEvent = null;
        [SerializeField] private UnityEvent response = null;

        //Monobehaviour
        //Subscribe to game event
        void OnEnable() => gameEvent.AddUnityEvent(response);

        //Unsubscribe to game event
        void OnDisable() => gameEvent.RemoveUnityEvent(response);
    }
}
