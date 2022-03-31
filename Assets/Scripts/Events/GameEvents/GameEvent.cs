using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

namespace CorruptCity.Event
{
    //Game event used to raise events from editor
    [CreateAssetMenu(fileName = "New_Game_Event", menuName = "Game_Event")]
    public class GameEvent : ScriptableObject
    {
        //Variables
        private readonly List<UnityEvent> listeners = new List<UnityEvent>();

        //Events
        public event Action RaiseGameEvent = null;

        //Methods
        //Add listener
        public void AddUnityEvent(UnityEvent unityEvent)
        {
            //Avoid errors
            bool canAdd = unityEvent != null && !listeners.Contains(unityEvent);

            if (canAdd)
                listeners.Add(unityEvent);
        }

        //Remove listener
        public void RemoveUnityEvent(UnityEvent unityEvent)
        {
            //Avoid errors
            bool canRemove = unityEvent != null && listeners.Contains(unityEvent);

            if (canRemove)
                listeners.Remove(unityEvent);
        }

        //Raise responses from listeneres
        public void RaiseListeners()
        {
            List<UnityEvent> auxiliaryList = new List<UnityEvent>();

            //Itinerate and duplicate list
            foreach (UnityEvent listener in listeners)
                auxiliaryList.Add(listener);

            //Itinerate auxiliary list and raise responses
            foreach (UnityEvent response in auxiliaryList)
            {
                //Avoid errors
                if (response == null)
                    listeners.Remove(response);
                else
                    response?.Invoke();
            }

            RaiseGameEvent?.Invoke();
        }
    }
}
