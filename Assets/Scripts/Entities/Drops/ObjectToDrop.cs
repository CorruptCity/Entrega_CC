using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CorruptCity.Entities
{
    /*
     * This object is used to store information of a specific drop
     */
    [Serializable]
    public struct ObjectToDrop
    {
        //Editor variables
        [Header("Drop information")]
#pragma warning disable IDE0044 // Add readonly modifier
        [SerializeField] private GameObject dropPrefab;
        [Range(0, 100)]
        [SerializeField] private float dropPercent;
#pragma warning restore IDE0044 // Add readonly modifier

        public GameObject DropPrefab { get => dropPrefab; }
        public float DropPercent { get => dropPercent; }
    }
}