using System;
using UnityEngine;
using UnityEngine.Events;

namespace CorruptCity.Events
{
    /*
     * Class used to releate layers to an event
     */
    [Serializable]
    public struct LayersResponse
    {
        //Editor variables
#pragma warning disable IDE0044 // Add readonly modifier
        [SerializeField] private int[] targetLayers;
        [SerializeField] private UnityEvent responseUnityEvent;
#pragma warning restore IDE0044 // Add readonly modifier

        //Atributes
        public UnityEvent ResponseUnityEvent { get => responseUnityEvent; }
        public int[] TargetLayers { get => targetLayers; }
    }
}